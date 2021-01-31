using System.Collections.Generic;

namespace BungieSharper.Schema.Destiny.Definitions.Reporting
{

    /// <summary>
    /// If you're going to report someone for a Terms of Service violation, you need to choose a category and reason for the report. This definition holds both the categories and the reasons within those categories, for simplicity and my own laziness' sake.
    /// Note tha this means that, to refer to a Reason by reasonHash, you need a combination of the reasonHash *and* the associated ReasonCategory's hash: there are some reasons defined under multiple categories.
    /// </summary>
    public class DestinyReportReasonCategoryDefinition : BungieSharper.Schema.Destiny.Definitions.DestinyDefinition
    {
        public Schema.Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }
        /// <summary>The specific reasons for the report under this category.</summary>
        public Dictionary<uint, Schema.Destiny.Definitions.Reporting.DestinyReportReasonDefinition> reasons { get; set; }
    }

    /// <summary>
    /// A specific reason for being banned. Only accessible under the related category (DestinyReportReasonCategoryDefinition) under which it is shown. Note that this means that report reasons' reasonHash are not globally unique: and indeed, entries like "Other" are defined under most categories for example.
    /// </summary>
    public class DestinyReportReasonDefinition
    {
        /// <summary>The identifier for the reason: they are only guaranteed unique under the Category in which they are found.</summary>
        public uint reasonHash { get; set; }
        public Schema.Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition displayProperties { get; set; }
    }
}