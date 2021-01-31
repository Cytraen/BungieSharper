namespace BungieSharper.Schema.Components
{
    /// <summary>
    /// The base class for any component-returning object that may need to indicate information about the state of the component being returned.
    /// </summary>
    public class ComponentResponse
    {
        public Schema.Components.ComponentPrivacySetting privacy { get; set; }
        /// <summary>If true, this component is disabled.</summary>
        public bool? disabled { get; set; }
    }

    /// <summary>
    /// A set of flags for reason(s) why the component populated in the way that it did. Inspect the individual flags for the reasons.
    /// </summary>
    public enum ComponentPrivacySetting
    {
        None = 0,
        Public = 1,
        Private = 2
    }
}