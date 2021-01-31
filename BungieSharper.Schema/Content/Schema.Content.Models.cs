using System.Collections.Generic;

namespace BungieSharper.Schema.Content.Models
{
    public class ContentTypeDescription
    {
        public string cType { get; set; }

        public string name { get; set; }

        public string contentDescription { get; set; }

        public string previewImage { get; set; }

        public int priority { get; set; }

        public string reminder { get; set; }

        public IEnumerable<Content.Models.ContentTypeProperty> properties { get; set; }

        public IEnumerable<Content.Models.TagMetadataDefinition> tagMetadata { get; set; }

        public Dictionary<string, Content.Models.TagMetadataItem> tagMetadataItems { get; set; }

        public IEnumerable<string> usageExamples { get; set; }

        public bool showInContentEditor { get; set; }

        public string typeOf { get; set; }

        public string bindIdentifierToProperty { get; set; }

        public string boundRegex { get; set; }

        public bool forceIdentifierBinding { get; set; }

        public bool allowComments { get; set; }

        public bool autoEnglishPropertyFallback { get; set; }

        public bool bulkUploadable { get; set; }

        public IEnumerable<Content.Models.ContentPreview> previews { get; set; }

        public bool suppressCmsPath { get; set; }

        public IEnumerable<Content.Models.ContentTypePropertySection> propertySections { get; set; }
    }

    public class ContentTypeProperty
    {
        public string name { get; set; }

        public string rootPropertyName { get; set; }

        public string readableName { get; set; }

        public string value { get; set; }

        public string propertyDescription { get; set; }

        public bool localizable { get; set; }

        public bool fallback { get; set; }

        public bool enabled { get; set; }

        public int order { get; set; }

        public bool visible { get; set; }

        public bool isTitle { get; set; }

        public bool required { get; set; }

        public int maxLength { get; set; }

        public int maxByteLength { get; set; }

        public int maxFileSize { get; set; }

        public string regexp { get; set; }

        public string validateAs { get; set; }

        public string rssAttribute { get; set; }

        public string visibleDependency { get; set; }

        public string visibleOn { get; set; }

        public Content.Models.ContentPropertyDataTypeEnum datatype { get; set; }

        public Dictionary<string, string> attributes { get; set; }

        public IEnumerable<Content.Models.ContentTypeProperty> childProperties { get; set; }

        public string contentTypeAllowed { get; set; }

        public string bindToProperty { get; set; }

        public string boundRegex { get; set; }

        public Dictionary<string, string> representationSelection { get; set; }

        public IEnumerable<Content.Models.ContentTypeDefaultValue> defaultValues { get; set; }

        public bool isExternalAllowed { get; set; }

        public string propertySection { get; set; }

        public int weight { get; set; }

        public string entitytype { get; set; }

        public bool isCombo { get; set; }

        public bool suppressProperty { get; set; }

        public IEnumerable<string> legalContentTypes { get; set; }

        public string representationValidationString { get; set; }

        public int minWidth { get; set; }

        public int maxWidth { get; set; }

        public int minHeight { get; set; }

        public int maxHeight { get; set; }

        public bool isVideo { get; set; }

        public bool isImage { get; set; }
    }

    public enum ContentPropertyDataTypeEnum
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
        public string whenClause { get; set; }

        public string whenValue { get; set; }

        public string defaultValue { get; set; }
    }

    public class TagMetadataDefinition
    {
        public string description { get; set; }

        public int order { get; set; }

        public IEnumerable<Content.Models.TagMetadataItem> items { get; set; }

        public string datatype { get; set; }

        public string name { get; set; }

        public bool isRequired { get; set; }
    }

    public class TagMetadataItem
    {
        public string description { get; set; }

        public string tagText { get; set; }

        public IEnumerable<string> groups { get; set; }

        public bool isDefault { get; set; }

        public string name { get; set; }
    }

    public class ContentPreview
    {
        public string name { get; set; }

        public string path { get; set; }

        public bool itemInSet { get; set; }

        public string setTag { get; set; }

        public int setNesting { get; set; }

        public int useSetId { get; set; }
    }

    public class ContentTypePropertySection
    {
        public string name { get; set; }

        public string readableName { get; set; }

        public bool collapsed { get; set; }
    }
}