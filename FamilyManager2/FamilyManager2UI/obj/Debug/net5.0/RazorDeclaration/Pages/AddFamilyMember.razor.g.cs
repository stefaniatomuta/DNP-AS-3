// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace FamilyManager2UI.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\_Imports.razor"
using FamilyManager2UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\_Imports.razor"
using FamilyManager2UI.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\Pages\AddFamilyMember.razor"
using FamilyManager2UI.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\Pages\AddFamilyMember.razor"
           [Authorize(Policy = Policies.IsAdmin)]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/AddFamilyMember")]
    public partial class AddFamilyMember : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 52 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\Pages\AddFamilyMember.razor"
       
    private string Type;
    private IList<Family> Families;
    
    protected override async Task OnInitializedAsync() {
        Type = "Adult";
        Families = FamilyData.GetFamilies().Where(f => f.Adults.Count < 2).ToList();
    }

    private void ChangeType(ChangeEventArgs arg) {
        Type = arg.Value?.ToString();
        if (Type.Equals("Adult")) {
            Families = FamilyData.GetFamilies().Where(f => f.Adults.Count < 2).ToList();
        }
        else {
            Families = FamilyData.GetFamilies().Where(f => f.Adults.Count > 0).ToList();
        }
    }

    private void AddNewMember(string streetName,int houseNumber) {
        NavMng.NavigateTo($"/AddMember/{streetName}/{houseNumber}/{Type}");
    }

    private void AddNewFamily() {
        NavMng.NavigateTo("/AddFamily");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IFamilyData FamilyData { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavMng { get; set; }
    }
}
#pragma warning restore 1591