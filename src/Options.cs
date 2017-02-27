using Microsoft.VisualStudio.Shell;
using System;
using System.ComponentModel;

namespace CssSorter
{
    public class Options : DialogPage
    {
        // General
        private const string _general = "General";

        [Category(_general)]
        [DisplayName("Mode")]
        [Description("Determines what algorithm to use for sorting the properties.")]
        [DefaultValue(Mode.SMACSS)]
        [TypeConverter(typeof(EnumConverter))]
        public Mode Mode { get; set; } = Mode.SMACSS;
    }

    public enum Mode
    {
        Alphabetically,
        SMACSS,
        Concentric,
    }
}
