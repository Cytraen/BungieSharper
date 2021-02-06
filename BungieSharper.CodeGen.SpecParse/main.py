import json
import os
import shutil
import urllib.request

spec_url = "https://raw.githubusercontent.com/Bungie-net/api/master/openapi.json"
file_name = "openapi.json"


def try_parse_int(value):
    try:
        return int(value), True
    except ValueError:
        return value, False


def try_parse_float(value):
    try:
        return float(value), True
    except ValueError:
        return value, False


def resolver(property_def):
    if isinstance(property_def, dict):
        return resolve_dict(property_def)
    if isinstance(property_def, list):
        return resolve_list(property_def)
    if isinstance(property_def, bool):
        return "bool"
    if isinstance(property_def, int):
        return "int"
    if isinstance(property_def, str):
        if try_parse_float(property_def)[1]:
            if try_parse_int(property_def)[1]:
                return "int"
            else:
                return "float"
        else:
            return "str"

    raise


def resolve_dict(dict_object):
    nested_dict = {}
    for dict_key in dict_object:
        nested_dict[dict_key] = resolver(dict_object[dict_key])
    return nested_dict


def resolve_list(list_object):
    if len(list_object) == 0:
        return []

    list_items_definition = {}
    is_list_of_dict = isinstance(list_object[0], dict)

    if not is_list_of_dict:
        return [resolver(list_object[0])]

    for list_item in list_object:
        if is_list_of_dict != isinstance(list_item, dict):
            raise
        list_items_definition = resolver(list_item)

    return [list_items_definition]


def recursive_dict_copy(copy_from, copy_to):
    if not isinstance(copy_from, dict):
        raise
    if not isinstance(copy_to, dict):
        raise

    for dict_key in copy_from:
        if dict_key not in copy_to:
            copy_to[dict_key] = copy_from[dict_key]

        elif isinstance(copy_from[dict_key], dict):
            copy_to[dict_key] = recursive_dict_copy(copy_from[dict_key], copy_to[dict_key])

        elif isinstance(copy_from[dict_key], list):
            if len(copy_from[dict_key]) != 0 and len(copy_to[dict_key]) == 0:
                copy_to[dict_key].append(copy_from[dict_key][0])
            if len(copy_from[dict_key]) != 0 and len(copy_to[dict_key]) != 0 and isinstance(copy_from[dict_key][0], dict):
                copy_to[dict_key][0] = recursive_dict_copy(copy_from[dict_key][0], copy_to[dict_key][0])

        elif copy_to[dict_key] != copy_from[dict_key]:
            collision_text = f"Collision on {dict_key}: {copy_to[dict_key]} vs. {copy_from[dict_key]}"

            if copy_to[dict_key] == "float" or copy_from[dict_key] == "float":
                if copy_to[dict_key] == "int" or copy_from[dict_key] == "int":
                    collision_text += ", assuming result is float"
                    copy_to[dict_key] = "float"

            print(collision_text)

    return copy_to


def recursive_list_copy(copy_from, copy_to):
    if not isinstance(copy_from, list) or len(copy_from) != 1:
        raise
    if not isinstance(copy_to, list) or len(copy_to) != 1:
        raise

    if isinstance(copy_from[0], dict):
        list_item = recursive_dict_copy(copy_from[0], copy_to[0])

    else:
        if copy_from[0] != copy_to[0]:
            raise
        list_item = copy_from[0]

    return [list_item]


def replace_handler(attr_to_replace, this_instance, base_instance):
    if attr_to_replace not in base_instance:
        base_instance[attr_to_replace] = this_instance

    elif isinstance(this_instance, list):
        base_instance[attr_to_replace] = \
            recursive_list_copy(this_instance, base_instance[attr_to_replace])

    elif isinstance(this_instance, dict):
        base_instance[attr_to_replace] = \
            recursive_dict_copy(this_instance, base_instance[attr_to_replace])

    else:
        base_instance[attr_to_replace] = this_instance


if __name__ == "__main__":
    base_entity_attributes = {}
    base_property_attributes = {}
    path_attributes = {}

    with urllib.request.urlopen(spec_url) as response, open(file_name, "wb") as out_file:
        shutil.copyfileobj(response, out_file)

    with open(file_name, "r", encoding="utf8") as json_file:
        text = json_file.read()

    spec_object = json.loads(text)

    entities = spec_object["components"]["schemas"]
    paths = spec_object["paths"]

    for key in entities:
        if "properties" in entities[key]:
            for property_item in entities[key]["properties"]:
                for property_attr in entities[key]["properties"][property_item]:
                    this_prop_attr_def = resolver(entities[key]["properties"][property_item][property_attr])
                    replace_handler(property_attr, this_prop_attr_def, base_property_attributes)

            entities[key].pop("properties")

        for attribute in entities[key]:
            this_attribute_definition = resolver(entities[key][attribute])
            replace_handler(attribute, this_attribute_definition, base_entity_attributes)

    for path in paths:
        for property_name in paths[path]:
            this_path_def = resolver(paths[path][property_name])
            replace_handler(property_name, this_path_def, path_attributes)

    base_attrs_string = json.dumps(base_entity_attributes, indent=4)
    prop_attrs_string = json.dumps(base_property_attributes, indent=4)
    path_attrs_string = json.dumps(path_attributes, indent=4)

    print("\n")
    print(path_attrs_string)

    with open("base_attrs_spec.json", "w", encoding="utf8") as json_file:
        json_file.write(base_attrs_string)

    with open("prop_attrs_spec.json", "w", encoding="utf8") as json_file:
        json_file.write(prop_attrs_string)

    with open("path_attrs_spec.json", "w", encoding="utf8") as json_file:
        json_file.write(path_attrs_string)

    if os.path.exists(file_name):
        os.remove(file_name)
