#pragma checksum "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\Pages\PersonDetails.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "15cf0142989525461b14b54303d69b52ad9ea195"
// <auto-generated/>
#pragma warning disable 1591
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
#line 2 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\Pages\PersonDetails.razor"
using Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\Pages\PersonDetails.razor"
using Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Person/{id:int}/{Firstname}/{Lastname}")]
    public partial class PersonDetails : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "container mt-6 mb-6 p-6 my-auto h-100 w-50");
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", "card p-4");
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", " image d-flex flex-column justify-content-center align-items-center");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "d-flex flex-row justify-content-center mt-3");
#nullable restore
#line 11 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\Pages\PersonDetails.razor"
             if (person.Sex.Equals("F")) {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(8, "<button class=\"btn btn-secondary mt-3\"><img src=\"/Images/girl.jpg\" height=\"100\" width=\"100\"><br></button>");
#nullable restore
#line 15 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\Pages\PersonDetails.razor"
            }
            else {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(9, "<button class=\"btn btn-secondary mt-3\"><img src=\"/Images/boy.png\" height=\"100\" width=\"100\"><br></button>");
#nullable restore
#line 20 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\Pages\PersonDetails.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\r\n            ");
            __builder.OpenElement(11, "div");
            __builder.OpenElement(12, "span");
            __builder.AddAttribute(13, "class", "mt-3");
            __builder.AddContent(14, 
#nullable restore
#line 23 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\Pages\PersonDetails.razor"
                                    person.FirstName

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(15, " ");
            __builder.AddContent(16, 
#nullable restore
#line 23 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\Pages\PersonDetails.razor"
                                                      person.LastName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\r\n            ");
            __builder.OpenElement(18, "div");
            __builder.OpenElement(19, "span");
            __builder.AddAttribute(20, "class", "mt-3");
            __builder.AddContent(21, "Age: ");
            __builder.AddContent(22, 
#nullable restore
#line 26 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\Pages\PersonDetails.razor"
                                         person.Age

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(23, "\r\n            ");
            __builder.OpenElement(24, "div");
            __builder.AddAttribute(25, "class", "d-flex flex-row justify-content-center align-items-center mt-3");
            __builder.OpenElement(26, "span");
            __builder.AddAttribute(27, "class", "idd1");
            __builder.AddContent(28, "Height: ");
            __builder.AddContent(29, 
#nullable restore
#line 29 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\Pages\PersonDetails.razor"
                                            person.Height

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(30, "\r\n            ");
            __builder.OpenElement(31, "div");
            __builder.AddAttribute(32, "class", "d-flex flex-row justify-content-center align-items-center mt-3");
            __builder.OpenElement(33, "span");
            __builder.AddAttribute(34, "class", "idd1");
            __builder.AddContent(35, "Weight: ");
            __builder.AddContent(36, 
#nullable restore
#line 32 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\Pages\PersonDetails.razor"
                                            person.Weight

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(37, "\r\n            ");
            __builder.OpenElement(38, "div");
            __builder.AddAttribute(39, "class", "d-flex flex-row justify-content-center align-items-center mt-3 w-25");
            __builder.AddMarkupContent(40, "\r\n                Sex:\r\n                ");
            __builder.OpenElement(41, "label");
            __builder.AddContent(42, 
#nullable restore
#line 36 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\Pages\PersonDetails.razor"
                         person.Sex

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(43, "\r\n            ");
            __builder.OpenElement(44, "div");
            __builder.AddAttribute(45, "class", "text mt-3");
            __builder.OpenElement(46, "span");
            __builder.AddContent(47, "Eye Color: ");
            __builder.AddContent(48, 
#nullable restore
#line 39 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\Pages\PersonDetails.razor"
                                  person.EyeColor

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(49, "\r\n            ");
            __builder.OpenElement(50, "div");
            __builder.AddAttribute(51, "class", "px-2 rounded mt-3");
            __builder.OpenElement(52, "span");
            __builder.AddAttribute(53, "class", "join");
            __builder.AddContent(54, "Hair Color: ");
            __builder.AddContent(55, 
#nullable restore
#line 42 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\Pages\PersonDetails.razor"
                                                person.HairColor

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 44 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\Pages\PersonDetails.razor"
             if (person is Adult) {
                Adult adult = (Adult) person;

#line default
#line hidden
#nullable disable
            __builder.OpenElement(56, "div");
            __builder.AddAttribute(57, "class", "px-2 rounded mt-3");
            __builder.OpenElement(58, "span");
            __builder.AddContent(59, "Job title: ");
            __builder.AddContent(60, 
#nullable restore
#line 47 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\Pages\PersonDetails.razor"
                                      adult.JobTitle.JobTitle

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 49 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\Pages\PersonDetails.razor"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\Pages\PersonDetails.razor"
             if (person is Child) {
                Child child = (Child) person;
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 52 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\Pages\PersonDetails.razor"
                 if (child.Pets.Count != 0) {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(61, "div");
            __builder.AddAttribute(62, "class", "px-2 rounded mt-3");
            __builder.AddMarkupContent(63, "\r\n                        Pets:\r\n");
#nullable restore
#line 55 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\Pages\PersonDetails.razor"
                         foreach (var pet in child.Pets) {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(64, "span");
            __builder.AddContent(65, 
#nullable restore
#line 56 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\Pages\PersonDetails.razor"
                                   pet.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 57 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\Pages\PersonDetails.razor"
                        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 59 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\Pages\PersonDetails.razor"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 59 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\Pages\PersonDetails.razor"
                 
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 64 "C:\Users\tomut\Desktop\DNP-AS-2\FamilyManager2\FamilyManager2UI\Pages\PersonDetails.razor"
       
    [Parameter]
    public int Id { set; get; }
    [Parameter]
    public string Firstname { set; get; }
    [Parameter]
    public string Lastname { set; get; }
    
    public string FirstLastName { get; set; }

    private Person person;

    protected override async Task OnInitializedAsync() {
        person = FamilyData.GetPersonByIdFirstLastName(Id, Firstname,Lastname);
        FirstLastName = $"{Firstname} {Lastname}";
    }
    

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IFamilyData FamilyData { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager navigationManager { get; set; }
    }
}
#pragma warning restore 1591
