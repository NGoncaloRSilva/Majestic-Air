#pragma checksum "D:\Work\PROGRAMAÇÃO\WEB\MVC.NetCore\NGoncaloRSilva\Projeto-Aeronave\Majestic Air\Airline\Views\Flights\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "750fc1cc1819825005ea82fa9b675de65616ea64"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Flights_Details), @"mvc.1.0.view", @"/Views/Flights/Details.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Work\PROGRAMAÇÃO\WEB\MVC.NetCore\NGoncaloRSilva\Projeto-Aeronave\Majestic Air\Airline\Views\_ViewImports.cshtml"
using Airline;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Work\PROGRAMAÇÃO\WEB\MVC.NetCore\NGoncaloRSilva\Projeto-Aeronave\Majestic Air\Airline\Views\_ViewImports.cshtml"
using Airline.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"750fc1cc1819825005ea82fa9b675de65616ea64", @"/Views/Flights/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b30c378dbc362d340729f06dadce816c2fe70956", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Flights_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Airline.Data.Entities.Flight>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Work\PROGRAMAÇÃO\WEB\MVC.NetCore\NGoncaloRSilva\Projeto-Aeronave\Majestic Air\Airline\Views\Flights\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Flight</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-4\">\r\n            ");
#nullable restore
#line 14 "D:\Work\PROGRAMAÇÃO\WEB\MVC.NetCore\NGoncaloRSilva\Projeto-Aeronave\Majestic Air\Airline\Views\Flights\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.FlightNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-8\">\r\n            ");
#nullable restore
#line 17 "D:\Work\PROGRAMAÇÃO\WEB\MVC.NetCore\NGoncaloRSilva\Projeto-Aeronave\Majestic Air\Airline\Views\Flights\Details.cshtml"
       Write(Html.DisplayFor(model => model.FlightNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-4\">\r\n            ");
#nullable restore
#line 20 "D:\Work\PROGRAMAÇÃO\WEB\MVC.NetCore\NGoncaloRSilva\Projeto-Aeronave\Majestic Air\Airline\Views\Flights\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Origin));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-8\">\r\n            ");
#nullable restore
#line 23 "D:\Work\PROGRAMAÇÃO\WEB\MVC.NetCore\NGoncaloRSilva\Projeto-Aeronave\Majestic Air\Airline\Views\Flights\Details.cshtml"
       Write(Html.DisplayFor(model => model.Origin.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n         <dt class=\"col-sm-4\">\r\n            ");
#nullable restore
#line 26 "D:\Work\PROGRAMAÇÃO\WEB\MVC.NetCore\NGoncaloRSilva\Projeto-Aeronave\Majestic Air\Airline\Views\Flights\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Destination));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-8\">\r\n            ");
#nullable restore
#line 29 "D:\Work\PROGRAMAÇÃO\WEB\MVC.NetCore\NGoncaloRSilva\Projeto-Aeronave\Majestic Air\Airline\Views\Flights\Details.cshtml"
       Write(Html.DisplayFor(model => model.Destination.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-4\">\r\n            ");
#nullable restore
#line 32 "D:\Work\PROGRAMAÇÃO\WEB\MVC.NetCore\NGoncaloRSilva\Projeto-Aeronave\Majestic Air\Airline\Views\Flights\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Day));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-8\">\r\n            ");
#nullable restore
#line 35 "D:\Work\PROGRAMAÇÃO\WEB\MVC.NetCore\NGoncaloRSilva\Projeto-Aeronave\Majestic Air\Airline\Views\Flights\Details.cshtml"
       Write(Html.DisplayFor(model => model.Day));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>");
            WriteLiteral("        <dt class=\"col-sm-4\">\r\n            ");
#nullable restore
#line 44 "D:\Work\PROGRAMAÇÃO\WEB\MVC.NetCore\NGoncaloRSilva\Projeto-Aeronave\Majestic Air\Airline\Views\Flights\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.AirshipName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-8\">\r\n            ");
#nullable restore
#line 47 "D:\Work\PROGRAMAÇÃO\WEB\MVC.NetCore\NGoncaloRSilva\Projeto-Aeronave\Majestic Air\Airline\Views\Flights\Details.cshtml"
       Write(Html.DisplayFor(model => model.AirshipName.AirshipName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt class=\"col-sm-4\">\r\n            Tickets:\r\n        </dt>\r\n        <dd class=\"col-sm-8\">\r\n            \r\n        </dd>\r\n\r\n        <dt class=\"col-sm-4\">\r\n            ");
#nullable restore
#line 58 "D:\Work\PROGRAMAÇÃO\WEB\MVC.NetCore\NGoncaloRSilva\Projeto-Aeronave\Majestic Air\Airline\Views\Flights\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.AirshipName.model.Tickets1stClass));

#line default
#line hidden
#nullable disable
            WriteLiteral(" Stock\r\n        </dt>\r\n        <dd class=\"col-sm-8\">\r\n            ");
#nullable restore
#line 61 "D:\Work\PROGRAMAÇÃO\WEB\MVC.NetCore\NGoncaloRSilva\Projeto-Aeronave\Majestic Air\Airline\Views\Flights\Details.cshtml"
       Write(Html.DisplayFor(model => model.AirshipName.model.Tickets1stClass));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-4\">\r\n            ");
#nullable restore
#line 64 "D:\Work\PROGRAMAÇÃO\WEB\MVC.NetCore\NGoncaloRSilva\Projeto-Aeronave\Majestic Air\Airline\Views\Flights\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.AirshipName.model.TicketsBusiness));

#line default
#line hidden
#nullable disable
            WriteLiteral(" Stock\r\n        </dt>\r\n        <dd class=\"col-sm-8\">\r\n            ");
#nullable restore
#line 67 "D:\Work\PROGRAMAÇÃO\WEB\MVC.NetCore\NGoncaloRSilva\Projeto-Aeronave\Majestic Air\Airline\Views\Flights\Details.cshtml"
       Write(Html.DisplayFor(model => model.AirshipName.model.TicketsBusiness));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-4\">\r\n            ");
#nullable restore
#line 70 "D:\Work\PROGRAMAÇÃO\WEB\MVC.NetCore\NGoncaloRSilva\Projeto-Aeronave\Majestic Air\Airline\Views\Flights\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.AirshipName.model.TicketsPremiumEconomy));

#line default
#line hidden
#nullable disable
            WriteLiteral(" Stock\r\n        </dt>\r\n        <dd class=\"col-sm-8\">\r\n            ");
#nullable restore
#line 73 "D:\Work\PROGRAMAÇÃO\WEB\MVC.NetCore\NGoncaloRSilva\Projeto-Aeronave\Majestic Air\Airline\Views\Flights\Details.cshtml"
       Write(Html.DisplayFor(model => model.AirshipName.model.TicketsPremiumEconomy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-4\">\r\n            ");
#nullable restore
#line 76 "D:\Work\PROGRAMAÇÃO\WEB\MVC.NetCore\NGoncaloRSilva\Projeto-Aeronave\Majestic Air\Airline\Views\Flights\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.AirshipName.model.TicketsEconomy));

#line default
#line hidden
#nullable disable
            WriteLiteral(" Stock\r\n        </dt>\r\n        <dd class=\"col-sm-8\">\r\n            ");
#nullable restore
#line 79 "D:\Work\PROGRAMAÇÃO\WEB\MVC.NetCore\NGoncaloRSilva\Projeto-Aeronave\Majestic Air\Airline\Views\Flights\Details.cshtml"
       Write(Html.DisplayFor(model => model.AirshipName.model.TicketsEconomy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n\r\n        <dt class = \"col-sm-4\">\r\n            ");
#nullable restore
#line 84 "D:\Work\PROGRAMAÇÃO\WEB\MVC.NetCore\NGoncaloRSilva\Projeto-Aeronave\Majestic Air\Airline\Views\Flights\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Price1stClass));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-8\">\r\n            ");
#nullable restore
#line 87 "D:\Work\PROGRAMAÇÃO\WEB\MVC.NetCore\NGoncaloRSilva\Projeto-Aeronave\Majestic Air\Airline\Views\Flights\Details.cshtml"
       Write(Html.DisplayFor(model => model.Price1stClass));

#line default
#line hidden
#nullable disable
            WriteLiteral("€\r\n        </dd>\r\n        <dt class = \"col-sm-4\">\r\n            ");
#nullable restore
#line 90 "D:\Work\PROGRAMAÇÃO\WEB\MVC.NetCore\NGoncaloRSilva\Projeto-Aeronave\Majestic Air\Airline\Views\Flights\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PriceBusiness));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-8\">\r\n            ");
#nullable restore
#line 93 "D:\Work\PROGRAMAÇÃO\WEB\MVC.NetCore\NGoncaloRSilva\Projeto-Aeronave\Majestic Air\Airline\Views\Flights\Details.cshtml"
       Write(Html.DisplayFor(model => model.PriceBusiness));

#line default
#line hidden
#nullable disable
            WriteLiteral("€\r\n        </dd>\r\n        <dt class = \"col-sm-4\">\r\n            ");
#nullable restore
#line 96 "D:\Work\PROGRAMAÇÃO\WEB\MVC.NetCore\NGoncaloRSilva\Projeto-Aeronave\Majestic Air\Airline\Views\Flights\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PricePremiumEconomy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-8\">\r\n            ");
#nullable restore
#line 99 "D:\Work\PROGRAMAÇÃO\WEB\MVC.NetCore\NGoncaloRSilva\Projeto-Aeronave\Majestic Air\Airline\Views\Flights\Details.cshtml"
       Write(Html.DisplayFor(model => model.PricePremiumEconomy));

#line default
#line hidden
#nullable disable
            WriteLiteral("€\r\n        </dd>\r\n        <dt class = \"col-sm-4\">\r\n            ");
#nullable restore
#line 102 "D:\Work\PROGRAMAÇÃO\WEB\MVC.NetCore\NGoncaloRSilva\Projeto-Aeronave\Majestic Air\Airline\Views\Flights\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PriceEconomy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-8\">\r\n            ");
#nullable restore
#line 105 "D:\Work\PROGRAMAÇÃO\WEB\MVC.NetCore\NGoncaloRSilva\Projeto-Aeronave\Majestic Air\Airline\Views\Flights\Details.cshtml"
       Write(Html.DisplayFor(model => model.PriceEconomy));

#line default
#line hidden
#nullable disable
            WriteLiteral("€\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "750fc1cc1819825005ea82fa9b675de65616ea6414774", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 110 "D:\Work\PROGRAMAÇÃO\WEB\MVC.NetCore\NGoncaloRSilva\Projeto-Aeronave\Majestic Air\Airline\Views\Flights\Details.cshtml"
                                                   WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "750fc1cc1819825005ea82fa9b675de65616ea6417061", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Airline.Data.Entities.Flight> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
