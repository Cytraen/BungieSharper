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
        nullable_str = ""
        if dict_key not in copy_to:
            nullable_str = "?"
            if dict_key + "?" not in copy_to:
                copy_to[dict_key + nullable_str] = copy_from[dict_key]

        if isinstance(copy_from[dict_key], dict):
            copy_to[dict_key + nullable_str] = recursive_dict_copy(copy_from[dict_key], copy_to[dict_key + nullable_str])

        elif isinstance(copy_from[dict_key], list):
            if len(copy_from[dict_key]) != 0 and len(copy_to[dict_key + nullable_str]) == 0:
                copy_to[dict_key + nullable_str].append(copy_from[dict_key][0])
            if len(copy_from[dict_key]) != 0 and len(copy_to[dict_key + nullable_str]) != 0 and isinstance(copy_from[dict_key][0], dict):
                copy_to[dict_key + nullable_str][0] = recursive_dict_copy(copy_from[dict_key][0], copy_to[dict_key + nullable_str][0])

        elif copy_to[dict_key + nullable_str] != copy_from[dict_key]:
            collision_text = f"Collision on {dict_key}: {copy_to[dict_key + nullable_str]} vs. {copy_from[dict_key]}"

            if copy_to[dict_key + nullable_str] == "float" or copy_from[dict_key] == "float":
                if copy_to[dict_key + nullable_str] == "int" or copy_from[dict_key] == "int":
                    collision_text += ", assuming result is float"
                    copy_to[dict_key + nullable_str] = "float"

            print(collision_text)

    keys_to_make_null = []

    for dict_key in copy_to:
        if dict_key not in copy_from and dict_key[-1] != "?":
            keys_to_make_null.append(dict_key)

    for dict_key in keys_to_make_null:
        copy_to[dict_key + "?"] = copy_to.pop(dict_key)

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
    response_attributes = {}

    with urllib.request.urlopen(spec_url) as response, open(file_name, "wb") as out_file:
        shutil.copyfileobj(response, out_file)

    with open(file_name, "r", encoding="utf8") as json_file:
        text = json_file.read()

    spec_object = json.loads(text)

    entities = spec_object["components"]["schemas"]
    paths = spec_object["paths"]
    responses = spec_object["components"]["responses"]

    for key in entities:
        if "properties" in entities[key]:
            for property_item in entities[key]["properties"]:
                property_template = {}
                for property_attr in entities[key]["properties"][property_item]:
                    this_prop_attr_def = resolver(entities[key]["properties"][property_item][property_attr])
                    property_template[property_attr] = this_prop_attr_def
                if len(base_property_attributes) == 0:
                    base_property_attributes = property_template
                else:
                    base_property_attributes = recursive_dict_copy(property_template, base_property_attributes)

            entities[key].pop("properties")

        attr_template = {}
        for attribute in entities[key]:
            this_attribute_definition = resolver(entities[key][attribute])
            attr_template[attribute] = this_attribute_definition
        if len(base_entity_attributes) == 0:
            base_entity_attributes = attr_template
        else:
            base_entity_attributes = recursive_dict_copy(attr_template, base_entity_attributes)

    for path in paths:
        prop_template = {}
        for property_name in paths[path]:
            this_path_def = resolver(paths[path][property_name])
            prop_template[property_name] = this_path_def
        if len(path_attributes) == 0:
            path_attributes = prop_template
        else:
            path_attributes = recursive_dict_copy(prop_template, path_attributes)

    for key in responses:
        attr_template = {}
        for attribute in responses[key]:
            this_response_definition = resolver(responses[key][attribute])
            attr_template[attribute] = this_response_definition
        if len(response_attributes) == 0:
            response_attributes = attr_template
        else:
            response_attributes = recursive_dict_copy(attr_template, response_attributes)

    base_attrs_string = json.dumps(base_entity_attributes, indent=4)
    prop_attrs_string = json.dumps(base_property_attributes, indent=4)
    path_attrs_string = json.dumps(path_attributes, indent=4)
    resp_attrs_string = json.dumps(response_attributes, indent=4)

    with open("base_attrs_spec.json", "w", encoding="utf8") as json_file:
        json_file.write(base_attrs_string)

    with open("prop_attrs_spec.json", "w", encoding="utf8") as json_file:
        json_file.write(prop_attrs_string)

    with open("path_attrs_spec.json", "w", encoding="utf8") as json_file:
        json_file.write(path_attrs_string)

    with open("resp_attrs_spec.json", "w", encoding="utf8") as json_file:
        json_file.write(resp_attrs_string)

    if os.path.exists(file_name):
        os.remove(file_name)
