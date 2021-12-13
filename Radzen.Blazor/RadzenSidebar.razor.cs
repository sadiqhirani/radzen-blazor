using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace Radzen.Blazor
{
    /// <summary>
    /// RadzenSidebar component.
    /// </summary>
    public partial class RadzenSidebar : RadzenComponentWithChildren
    {
        static string defaultStyle = "top:51px;bottom:57px;width:250px;transform:translateX(0px);";
        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        /// <value>The style.</value>
        [Parameter]
        public override string Style { get; set; } = defaultStyle;

        /// <inheritdoc />
        protected override string GetComponentCssClass()
        {
            return Expanded ? "rz-sidebar rz-sidebar-expanded" : "rz-sidebar";
        }

        /// <summary>
        /// Toggles this instance expanded state.
        /// </summary>
        public void Toggle()
        {
            Expanded = !Expanded;

            StateHasChanged();
        }

        /// <summary>
        /// Gets the style.
        /// </summary>
        /// <returns>System.String.</returns>
        protected string GetStyle()
        {
            var style = new Dictionary<string, string>(CurrentStyle);

            var width = style.ContainsKey("width") ? style["width"] : "250px";
            var top = style.ContainsKey("top") ? style["top"] : "51px";
            var bottom = style.ContainsKey("bottom") ? style["bottom"] : "57px";

            if (style.ContainsKey("width"))
            {
                style["width"] = Expanded ? width : "0px";
            }
            else
            {
                style.Add("width", Expanded ? width : "0px");
            }

            if (style.ContainsKey("top"))
            {
                style["top"] = top;
            }
            else
            {
                style.Add("top", top);
            }

            if (style.ContainsKey("bottom"))
            {
                style["bottom"] = bottom;
            }
            else
            {
                style.Add("bottom", bottom);
            }

            if (style.ContainsKey("transform"))
            {
                style["transform"] = Expanded ? "transform:translateX(0px)" : "transform:translateX(-100%)";
            }
            else
            {
                style.Add("transform", Expanded ? "transform:translateX(0px)" : "transform:translateX(-100%)");
            }

            return $"{string.Join(";", style.Select(s => $"{s.Key}:{s.Value}"))}";
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="RadzenSidebar"/> is expanded.
        /// </summary>
        /// <value><c>true</c> if expanded; otherwise, <c>false</c>.</value>
        [Parameter]
        public bool Expanded { get; set; } = true;

        /// <summary>
        /// Gets or sets the expanded changed callback.
        /// </summary>
        /// <value>The expanded changed callback.</value>
        [Parameter]
        public EventCallback<bool> ExpandedChanged { get; set; }
    }
}
