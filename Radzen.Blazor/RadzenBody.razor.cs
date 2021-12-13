using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace Radzen.Blazor
{
    /// <summary>
    /// RadzenBody component.
    /// </summary>
    public partial class RadzenBody : RadzenComponentWithChildren
    {
        static string defaultStyle = "margin-top: 51px; margin-bottom: 57px; margin-left:250px;";
        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        /// <value>The style.</value>
        [Parameter]
        public override string Style { get; set; } = defaultStyle;

        /// <inheritdoc />
        protected override string GetComponentCssClass()
        {
            return Expanded ? "body body-expanded" : "body";
        }

        /// <summary>
        /// Toggles this instance width and left margin.
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

            var marginLeft = style.ContainsKey("margin-left") ? style["margin-left"] : "250px";
            var marginTop = style.ContainsKey("margin-top") ? style["margin-top"] : "51px";
            var marginBottom = style.ContainsKey("margin-bottom") ? style["margin-bottom"] : "57px";

            if (style.ContainsKey("margin-left"))
            {
                style["margin-left"] = Expanded ? "0px" : marginLeft;
            }
            else 
            {
                style.Add("margin-left", Expanded ? "0px" : marginLeft);
            }

            if (style.ContainsKey("margin-top"))
            {
                style["margin-top"] = marginTop;
            }
            else
            {
                style.Add("margin-top", marginTop);
            }

            if (style.ContainsKey("margin-bottom"))
            {
                style["margin-bottom"] = marginBottom;
            }
            else
            {
                style.Add("margin-bottom", marginBottom);
            }

            return $"{string.Join(";", style.Select(s => $"{s.Key}:{s.Value}"))}";
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="RadzenBody"/> is expanded.
        /// </summary>
        /// <value><c>true</c> if expanded; otherwise, <c>false</c>.</value>
        [Parameter]
        public bool Expanded { get; set; } = false;

        /// <summary>
        /// Gets or sets a callback raised when the component is expanded or collapsed.
        /// </summary>
        /// <value>The expanded changed callback.</value>
        [Parameter]
        public EventCallback<bool> ExpandedChanged { get; set; }
    }
}
