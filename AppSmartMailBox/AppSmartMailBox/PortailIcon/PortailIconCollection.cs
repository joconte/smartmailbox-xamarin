using Plugin.Iconize;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSmartMailBox.PortailIcon
{
    /// <summary>
    /// Defines the <see cref="PortailIconCollection" /> icon collection.
    /// </summary>
    public static class PortailIconCollection
    {
        /// <summary>
        /// Gets the icons.
        /// </summary>
        /// <value>The icons.</value>
        public static IList<IIcon> Icons { get; } = new List<IIcon>();

        /// <summary>
        /// Initializes the <see cref="PortailIconCollection" /> class.
        /// </summary>

        //Rajouter les glyphicons ici
        static PortailIconCollection()
        {
            Icons.Add("fa-dashboard", '\uf0e4');
            Icons.Add("fa-calendar-check-o", '\uf274');
            Icons.Add("fa-clipboard", '\uf0ea');
            Icons.Add("fa-pie-chart", '\uf200');
            Icons.Add("fa-accident-o", '\ue902');
            Icons.Add("fa-file-pdf", '\uf1c1');
            Icons.Add("fa-legal", '\uf0e3');
            Icons.Add("fa-user-circle", '\uf2be');
            Icons.Add("fa-commenting", '\uf27a');
            Icons.Add("fa-user", '\uf007');
            Icons.Add("fa-info-circle", '\uf05a');
            Icons.Add("fa-file-pdf-o", '\uf1c1');
            Icons.Add("fa-exclamation-triangle", '\uf071');
            Icons.Add("fa-user-plus", '\uf234');
            Icons.Add("fa-plus-circle", '\uf055');
            Icons.Add("fa-group", '\uf0c0');
            Icons.Add("fa-user-md", '\uf0f0');
            Icons.Add("fa-long-arrow-right", '\uf178');
            Icons.Add("fa-building-o", '\uf0f7');
            Icons.Add("fa-at", '\uf1fa');
            Icons.Add("fa-check", '\uf00c');
            Icons.Add("fa-close", '\uf00d');
            Icons.Add("fa-truck", '\uf0d1');
            Icons.Add("fa-lightbulb-o", '\uf0eb');
            Icons.Add("fa-circle", '\uf111');
            Icons.Add("fa-check-circle", '\uf058');
            Icons.Add("fa-power-off", '\uf011');
            Icons.Add("fa-folder-open", '\uf07c');
            Icons.Add("fa-folder-open-o", '\uf115');
            Icons.Add("fa-calendar", '\uf073');
            Icons.Add("fa-euro", '\uf153');
            Icons.Add("fa-bank", '\uf19c');
            Icons.Add("fa-file", '\uf15b');
            Icons.Add("fa-envelope", '\uf0e0');
            Icons.Add("fa-hospital-o", '\uf0f8');
            Icons.Add("fa-send", '\uf1d8');
            Icons.Add("fa-clock-o", '\uf017');
            Icons.Add("fa-envelope-o", '\uf003'); 
        }
    }
}
