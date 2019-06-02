using Plugin.Iconize;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSmartMailBox.PortailIcon
{
    /// <summary>
    /// Defines the <see cref="PortailIconModule" /> icon module.
    /// </summary>
    /// <seealso cref="Plugin.Iconize.IconModule" />
    public sealed class PortailIconModule : IconModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PortailIconModule" /> class.
        /// </summary>
        public PortailIconModule()
            : base("Portail Icons", "PortailIcons", "ethac.ttf", PortailIconCollection.Icons)
        {
            // Intentionally left blank
        }
    }
}
