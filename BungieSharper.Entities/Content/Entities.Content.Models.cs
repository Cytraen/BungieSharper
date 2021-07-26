using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Content.Models
{
    public class ContentTypeDescription
    {
        [JsonPropertyName("cType")]
        public string CType { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("contentDescription")]
        public string ContentDescription { get; set; }

        [JsonPropertyName("previewImage")]
        public string PreviewImage { get; set; }

        [JsonPropertyName("priority")]
        public int Priority { get; set; }

        [JsonPropertyName("reminder")]
        public string Reminder { get; set; }

        [JsonPropertyName("properties")]
        public IEnumerable<Content.Models.ContentTypeProperty> Properties { get; set; }

        [JsonPropertyName("tagMetadata")]
        public IEnumerable<Content.Models.TagMetadataDefinition> TagMetadata { get; set; }

        [JsonPropertyName("tagMetadataItems")]
        public Dictionary<string, Content.Models.TagMetadataItem> TagMetadataItems { get; set; }

        [JsonPropertyName("usageExamples")]
        public IEnumerable<string> UsageExamples { get; set; }

        [JsonPropertyName("showInContentEditor")]
        public bool ShowInContentEditor { get; set; }

        [JsonPropertyName("typeOf")]
        public string TypeOf { get; set; }

        [JsonPropertyName("bindIdentifierToProperty")]
        public string BindIdentifierToProperty { get; set; }

        [JsonPropertyName("boundRegex")]
        public string BoundRegex { get; set; }

        [JsonPropertyName("forceIdentifierBinding")]
        public bool ForceIdentifierBinding { get; set; }

        [JsonPropertyName("allowComments")]
        public bool AllowComments { get; set; }

        [JsonPropertyName("autoEnglishPropertyFallback")]
        public bool AutoEnglishPropertyFallback { get; set; }

        [JsonPropertyName("bulkUploadable")]
        public bool BulkUploadable { get; set; }

        [JsonPropertyName("previews")]
        public IEnumerable<Content.Models.ContentPreview> Previews { get; set; }

        [JsonPropertyName("suppressCmsPath")]
        public bool SuppressCmsPath { get; set; }

        [JsonPropertyName("propertySections")]
        public IEnumerable<Content.Models.ContentTypePropertySection> PropertySections { get; set; }
    }

    public class ContentTypeProperty
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("rootPropertyName")]
        public string RootPropertyName { get; set; }

        [JsonPropertyName("readableName")]
        public string ReadableName { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("propertyDescription")]
        public string PropertyDescription { get; set; }

        [JsonPropertyName("localizable")]
        public bool Localizable { get; set; }

        [JsonPropertyName("fallback")]
        public bool Fallback { get; set; }

        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        [JsonPropertyName("order")]
        public int Order { get; set; }

        [JsonPropertyName("visible")]
        public bool Visible { get; set; }

        [JsonPropertyName("isTitle")]
        public bool IsTitle { get; set; }

        [JsonPropertyName("required")]
        public bool Required { get; set; }

        [JsonPropertyName("maxLength")]
        public int MaxLength { get; set; }

        [JsonPropertyName("maxByteLength")]
        public int MaxByteLength { get; set; }

        [JsonPropertyName("maxFileSize")]
        public int MaxFileSize { get; set; }

        [JsonPropertyName("regexp")]
        public string Regexp { get; set; }

        [JsonPropertyName("validateAs")]
        public string ValidateAs { get; set; }

        [JsonPropertyName("rssAttribute")]
        public string RssAttribute { get; set; }

        [JsonPropertyName("visibleDependency")]
        public string VisibleDependency { get; set; }

        [JsonPropertyName("visibleOn")]
        public string VisibleOn { get; set; }

        [JsonPropertyName("datatype")]
        public ContentPropertyDataTypeEnum Datatype { get; set; }

        [JsonPropertyName("attributes")]
        public Dictionary<string, string> Attributes { get; set; }

        [JsonPropertyName("childProperties")]
        public IEnumerable<Content.Models.ContentTypeProperty> ChildProperties { get; set; }

        [JsonPropertyName("contentTypeAllowed")]
        public string ContentTypeAllowed { get; set; }

        [JsonPropertyName("bindToProperty")]
        public string BindToProperty { get; set; }

        [JsonPropertyName("boundRegex")]
        public string BoundRegex { get; set; }

        [JsonPropertyName("representationSelection")]
        public Dictionary<string, string> RepresentationSelection { get; set; }

        [JsonPropertyName("defaultValues")]
        public IEnumerable<Content.Models.ContentTypeDefaultValue> DefaultValues { get; set; }

        [JsonPropertyName("isExternalAllowed")]
        public bool IsExternalAllowed { get; set; }

        [JsonPropertyName("propertySection")]
        public string PropertySection { get; set; }

        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        [JsonPropertyName("entitytype")]
        public string Entitytype { get; set; }

        [JsonPropertyName("isCombo")]
        public bool IsCombo { get; set; }

        [JsonPropertyName("suppressProperty")]
        public bool SuppressProperty { get; set; }

        [JsonPropertyName("legalContentTypes")]
        public IEnumerable<string> LegalContentTypes { get; set; }

        [JsonPropertyName("representationValidationString")]
        public string RepresentationValidationString { get; set; }

        [JsonPropertyName("minWidth")]
        public int MinWidth { get; set; }

        [JsonPropertyName("maxWidth")]
        public int MaxWidth { get; set; }

        [JsonPropertyName("minHeight")]
        public int MinHeight { get; set; }

        [JsonPropertyName("maxHeight")]
        public int MaxHeight { get; set; }

        [JsonPropertyName("isVideo")]
        public bool IsVideo { get; set; }

        [JsonPropertyName("isImage")]
        public bool IsImage { get; set; }
    }

    public enum ContentPropertyDataTypeEnum : int
    {
        None = 0,
        Plaintext = 1,
        Html = 2,
        Dropdown = 3,
        List = 4,
        Json = 5,
        Content = 6,
        Representation = 7,
        Set = 8,
        File = 9,
        FolderSet = 10,
        Date = 11,
        MultilinePlaintext = 12,
        DestinyContent = 13,
        Color = 14
    }

    public class ContentTypeDefaultValue
    {
        [JsonPropertyName("whenClause")]
        public string WhenClause { get; set; }

        [JsonPropertyName("whenValue")]
        public string WhenValue { get; set; }

        [JsonPropertyName("defaultValue")]
        public string DefaultValue { get; set; }
    }

    public class TagMetadataDefinition
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("order")]
        public int Order { get; set; }

        [JsonPropertyName("items")]
        public IEnumerable<Content.Models.TagMetadataItem> Items { get; set; }

        [JsonPropertyName("datatype")]
        public string Datatype { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("isRequired")]
        public bool IsRequired { get; set; }
    }

    public class TagMetadataItem
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("tagText")]
        public string TagText { get; set; }

        [JsonPropertyName("groups")]
        public IEnumerable<string> Groups { get; set; }

        [JsonPropertyName("isDefault")]
        public bool IsDefault { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class ContentPreview
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("path")]
        public string Path { get; set; }

        [JsonPropertyName("itemInSet")]
        public bool ItemInSet { get; set; }

        [JsonPropertyName("setTag")]
        public string SetTag { get; set; }

        [JsonPropertyName("setNesting")]
        public int SetNesting { get; set; }

        [JsonPropertyName("useSetId")]
        public int UseSetId { get; set; }
    }

    public class ContentTypePropertySection
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("readableName")]
        public string ReadableName { get; set; }

        [JsonPropertyName("collapsed")]
        public bool Collapsed { get; set; }
    }
}