#pragma checksum "C:\Users\bbdnet2231\Documents\CSharp_SeatBooking\Views\Checkout\PaymentSuccess.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "351460d7ca3c5723c55b07f1cfd7e1f6df596842"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Checkout_PaymentSuccess), @"mvc.1.0.view", @"/Views/Checkout/PaymentSuccess.cshtml")]
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
#line 2 "C:\Users\bbdnet2231\Documents\CSharp_SeatBooking\Views\_ViewImports.cshtml"
using Csharp_Seat_Booking_System;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\bbdnet2231\Documents\CSharp_SeatBooking\Views\_ViewImports.cshtml"
using Csharp_Seat_Booking_System.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\bbdnet2231\Documents\CSharp_SeatBooking\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"351460d7ca3c5723c55b07f1cfd7e1f6df596842", @"/Views/Checkout/PaymentSuccess.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7413d97202b5fa6c2ba23097676fd39f6c8abc7", @"/Views/_ViewImports.cshtml")]
    public class Views_Checkout_PaymentSuccess : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\bbdnet2231\Documents\CSharp_SeatBooking\Views\Checkout\PaymentSuccess.cshtml"
  
    ViewData["Title"] = "Payment Success";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    <div class=""form-group"">
        <div class=""alert alert-success"" role=""alert"">
            <h2><b>Payment Success</b></h2>
            <p>Your payment has been successfully processed, an invoice will be emailed to you.</p>
        </div>
    </div>
</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
