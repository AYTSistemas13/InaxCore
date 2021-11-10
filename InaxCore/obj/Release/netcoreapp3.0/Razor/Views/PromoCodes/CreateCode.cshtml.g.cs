#pragma checksum "C:\Users\sistemas13\Downloads\InaxCore\InaxCore\Views\PromoCodes\CreateCode.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d86321b5b6c29d6b4b2ff70e3cffbced0a258959"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PromoCodes_CreateCode), @"mvc.1.0.view", @"/Views/PromoCodes/CreateCode.cshtml")]
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
#line 1 "C:\Users\sistemas13\Downloads\InaxCore\InaxCore\Views\_ViewImports.cshtml"
using InaxCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\sistemas13\Downloads\InaxCore\InaxCore\Views\_ViewImports.cshtml"
using InaxCore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d86321b5b6c29d6b4b2ff70e3cffbced0a258959", @"/Views/PromoCodes/CreateCode.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de2440f23d8fea7a6de71ba0896f6fbc3bb152e4", @"/Views/_ViewImports.cshtml")]
    public class Views_PromoCodes_CreateCode : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<StoreSite>>
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\sistemas13\Downloads\InaxCore\InaxCore\Views\PromoCodes\CreateCode.cshtml"
  
    ViewData["Title"] = "CreateCode";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <div class=""container-fluid mx-0 my-5 pt-5"">
        <div class=""row"">
            <div class=""col-2"">
                <div class=""form-group"">
                    <label for=""promoCodeInput"">Código Promocional</label>
                    <input type=""text"" class=""form-control"" style=""text-transform: uppercase;"" id=""promoCodeInput"" placeholder=""Ejemplo: EMPRENDEDOR2021"">
                    <small id=""promoCodeInputSmall"" class=""form-text text-muted"">Puedes generar el código que desees.</small>
                </div>
                <div class=""form-group"">
                    <label for=""siteSelector"">Selecciona familia</label>
                    <select id=""familySelector"" name=""familySelected[]"" multiple placeholder=""Selecciona las familias"">
");
#nullable restore
#line 19 "C:\Users\sistemas13\Downloads\InaxCore\InaxCore\Views\PromoCodes\CreateCode.cshtml"
                         foreach (ItemFamily family in ViewData["familyList"] as List<ItemFamily>)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d86321b5b6c29d6b4b2ff70e3cffbced0a2589594529", async() => {
#nullable restore
#line 21 "C:\Users\sistemas13\Downloads\InaxCore\InaxCore\Views\PromoCodes\CreateCode.cshtml"
                                                      Write(family.FamilyName);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 21 "C:\Users\sistemas13\Downloads\InaxCore\InaxCore\Views\PromoCodes\CreateCode.cshtml"
                           WriteLiteral(family.FamilyName);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 22 "C:\Users\sistemas13\Downloads\InaxCore\InaxCore\Views\PromoCodes\CreateCode.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </select>
                </div>
                <button type=""button"" id=""filterByFamily"" class=""btn btn-primary"">Filtrar</button>
                <div class=""form-group"">
                    <label for=""startDate"">Fecha de inicio</label>
                    <input id=""startDate"" type=""date"" min=""1000-01-01""
                           max=""3000-12-31"" class=""form-control"">
                </div>
                <div class=""form-group"">
                    <label for=""expirationDate"">Fecha de expiración</label>
                    <input id=""expirationDate"" type=""date"" min=""1000-01-01""
                           max=""3000-12-31"" class=""form-control"">
                </div>
                <div class=""form-group"">
                    <label for=""siteSelector"">Selecciona sitio</label>
                    <select id=""siteSelector"" name=""siteSelected[]"" multiple placeholder=""Selecciona los sitios"">
");
#nullable restore
#line 39 "C:\Users\sistemas13\Downloads\InaxCore\InaxCore\Views\PromoCodes\CreateCode.cshtml"
                         foreach (StoreSite site in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d86321b5b6c29d6b4b2ff70e3cffbced0a2589597879", async() => {
#nullable restore
#line 41 "C:\Users\sistemas13\Downloads\InaxCore\InaxCore\Views\PromoCodes\CreateCode.cshtml"
                                                    Write(site.siteName);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 41 "C:\Users\sistemas13\Downloads\InaxCore\InaxCore\Views\PromoCodes\CreateCode.cshtml"
                               WriteLiteral(site.siteId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 42 "C:\Users\sistemas13\Downloads\InaxCore\InaxCore\Views\PromoCodes\CreateCode.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </select>
                </div>
                <button type=""button"" id=""createCode"" class=""btn btn-primary"">Crear</button>
            </div>
            <div class=""col-10"">
                <table class=""table table-bordered"" id=""itemsTable"">
                    <thead>
                        <tr>
                            <th width=""15%"">Artículo</th>
                            <th width=""60%"">Nombre</th>
                            <th width=""10%"">% Desc.</th>
                            <th width=""15%"">C. Mínima</th>
                        </tr>
                    </thead>
                    <tbody id=""itemsTableBody""></tbody>
                </table>
            </div>
");
            WriteLiteral("        </div>\r\n    </div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@" 
<script>
    var currentMultiselect = null;
    var itemsDataTable;
    var currentItemsSelected = null;
    $('#filterByFamily').click(() => {
        let familyList = $('#familySelector').val();
        if (familyList.length <= 0) {
            toastr.warning('Favor de ingresar al menos una familia');
            return;
        }
        $('body').attr('data-msj', 'Procesando Petición ...');
        $('body').addClass('load-ajax');
        $('body').append('<div class=""lean-overlay""></div>');
        if (itemsDataTable != null) {
            itemsDataTable.destroy();
            $('#itemsTable tbody').html('');
            let itemsList = {};
");
                WriteLiteral(@"            let itemDiscountList = $('.itemDiscount');
            let itemMinQuantityList = $('.itemMinQuantity');
            $.each(itemDiscountList, (index, value) => {
                if ($(value).val() == '') return;
                itemsList[$(value).data('id')] = {};
                itemsList[$(value).data('id')].itemDiscount = $(value).val();
            });
            $.each(itemMinQuantityList, (index, value) => {
                if ($(value).val() == '') return;
                console.log($(value).data('id'));
                if (itemsList[$(value).data('id')]) {
                    itemsList[$(value).data('id')].itemMinQuantity = $(value).val();
                }
            });
            currentItemsSelected = itemsList;
            $.get('");
#nullable restore
#line 105 "C:\Users\sistemas13\Downloads\InaxCore\InaxCore\Views\PromoCodes\CreateCode.cshtml"
              Write(Url.Action("GetItemsFamily", "PromoCodes"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', { familyList: Object.assign({}, familyList) }).done((data) => {
                $.each(data.message, (key, value) => {
                    if (currentItemsSelected[value.itemNumber]) {
                        $('#itemsTableBody').append(`<tr class='bg-success text-white'>
                        <td width=""15%"">${value.itemNumber}</td>
                        <td width=""60%"">${value.searchName}</td>
                        <td width=""10%""><input type='number' class='form-control itemDiscount' data-id='${value.itemNumber}' onchange='verifyInputs(this)' style='border:0!important;' placeholder='ej. 10' value='${currentItemsSelected[value.itemNumber].itemDiscount}'></input></td>
                        <td width=""15%""><input type='number' class='form-control itemMinQuantity' data-id='${value.itemNumber}' onchange='verifyInputs(this)' style='border:0!important;' placeholder='ej. 10' value='${currentItemsSelected[value.itemNumber].itemMinQuantity}'></input></td>
                        </tr>`);
        ");
                WriteLiteral(@"            } else {
                        $('#itemsTableBody').append(`<tr>
                        <td width=""15%"">${value.itemNumber}</td>
                        <td width=""60%"">${value.searchName}</td>
                        <td width=""10%""><input type='number' class='form-control itemDiscount' data-id='${value.itemNumber}' onchange='verifyInputs(this)' style='border:0!important;' placeholder='ej. 10'></input></td>
                        <td width=""15%""><input type='number' class='form-control itemMinQuantity' data-id='${value.itemNumber}' onchange='verifyInputs(this)' style='border:0!important;' placeholder='ej. 10' value='0'></input></td>
                        </tr>`);
                    }
                });
                itemsDataTable = $('#itemsTable').DataTable({
                    ""scrollY"": ""60vh"",
                    ""scrollCollapse"": true,
                    ""paging"": false,
                    ""responsive"": true,
                    ""destroy"": true,
                }");
                WriteLiteral(");\r\n                $(\'body\').removeClass(\'load-ajax\');\r\n                $(\'body .lean-overlay\').remove();\r\n            });\r\n        } else {\r\n            $.get(\'");
#nullable restore
#line 134 "C:\Users\sistemas13\Downloads\InaxCore\InaxCore\Views\PromoCodes\CreateCode.cshtml"
              Write(Url.Action("GetItemsFamily", "PromoCodes"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', { familyList: Object.assign({}, familyList) }).done((data) => {
                $.each(data.message, (key, value) => {
                        $('#itemsTableBody').append(`<tr>
                        <td width=""15%"">${value.itemNumber}</td>
                        <td width=""60%"">${value.searchName}</td>
                        <td width=""10%""><input type='number' class='form-control itemDiscount' data-id='${value.itemNumber}' onchange='verifyInputs(this)' style='border:0!important;' placeholder='ej. 10'></input></td>
                        <td width=""15%""><input type='number' class='form-control itemMinQuantity' data-id='${value.itemNumber}' onchange='verifyInputs(this)' style='border:0!important;' placeholder='ej. 10' value='0'></input></td>
                        </tr>`);
                });
                itemsDataTable = $('#itemsTable').DataTable({
                    ""scrollY"": ""60vh"",
                    ""scrollCollapse"": true,
                    ""paging"": false,
                 ");
                WriteLiteral(@"   ""responsive"": true,
                    ""destroy"": true,
                });
                $('body').removeClass('load-ajax');
                $('body .lean-overlay').remove();
            });
        }
    });

    $('#familySelector').selectize();
    $('#siteSelector').selectize();

    var items = []
    $('#siteSelector').on('change', function () {
        if ($(this).hasClass('selectized')) {
            if (this.value == 'All') {
                var control = $('#siteSelector')[0].selectize
                control.destroy()
                control._events = { change: [] };
                $('#siteSelector').prop('multiple', false)
                $('#siteSelector').val('All')
                $('#siteSelector').selectize()
                items = []
            } else {
                var control = $('#siteSelector')[0].selectize
                if (control.items.includes('All')) {
                    control.destroy()
                    control._events = { change: [] }");
                WriteLiteral(@";
                    $('#siteSelector').prop('multiple', false)
                    $('#siteSelector').val('All')
                    $('#siteSelector').selectize()
                    items = []
                } else {
                    control = $('#siteSelector')[0].selectize
                    items = control.items
                    control.destroy()
                    control._events = { change: [] };
                    $('#siteSelector').prop('multiple', 'multiple')
                    $('#siteSelector').val(items)
                    $('#siteSelector').selectize()
                    //console.log(control.items)
                }
            }
        }
    })

    function verifyInputs(element) {
        if ($(element).hasClass('itemDiscount')) {
            if ($(element).val() > 100) {
                toastr.warning('El descuento no puede sobrepasar el 100%');
                $(element).val(100)
            }
        }
        let trElement = $(element).parent().pa");
                WriteLiteral(@"rent();
        let minQuantityItem = $(element).parent().siblings().last()[0];
        minQuantityItem = $(minQuantityItem).children()[0];
        console.log($(element).val());
        if ($(element).val() == '') {
            if ($(trElement).hasClass('bg-success text-white')) {
                $(trElement).removeClass('bg-success text-white');
            }
            return;
        }
        if ($(minQuantityItem).val() != '') {
            console.log($(element).parent().parent());
            $(trElement).addClass('bg-success text-white');
        } else {
            if ($(trElement).hasClass('bg-success text-white')) {
                $(trElement).removeClass('bg-success text-white');
            }
        }
    }

    $('#createCode').click(() => {
        if ($('#promoCodeInput').val() == '') {
            toastr.warning('Favor de ingresar el código promocional');
            return;
        } else if ($('#promoCodeInput').val().length > 20) {
            toastr.warning('");
                WriteLiteral(@"El nombre no debe de tener un máximo de 20 caracteres');
            return;
        }
        if ($('#familySelector').val().length <= 0) {
            toastr.warning('Favor de ingresar al menos una familia');
            return;
        }
        if ($('#siteSelector').val().length <= 0) {
            toastr.warning('Favor de ingresar al menos un sitio');
            return;
        }
        if ($('#expirationDate').val() == '') {
            toastr.warning('Favor de ingresar la fecha de expiración');
            return;
        }
        if ($('#startDate').val() == '') {
            toastr.warning('Favor de ingresar la fecha de inicio');
            return;
        }
        $('input[type=search]').val('');
        itemsDataTable.search('').draw();
        let itemsList = {};
        let itemDiscountList = $('.itemDiscount');
        let itemMinQuantityList = $('.itemMinQuantity');
        $.each(itemDiscountList, (index, value) => {
            if ($(value).val() == '') return;");
                WriteLiteral(@"
            itemsList[$(value).data('id')] = {};
            itemsList[$(value).data('id')].itemDiscount = $(value).val();
        });
        $.each(itemMinQuantityList, (index, value) => {
            if ($(value).val() == '') return;
            console.log($(value).data('id'));
            if (itemsList[$(value).data('id')]) {
                itemsList[$(value).data('id')].itemMinQuantity = $(value).val();
            }
        });
        if (Object.keys(itemsList).length <= 0) {
            toastr.warning('Favor de configurar por lo menos un artículo');
            return;
        }
        let promoCode = $('#promoCodeInput').val().toUpperCase();
        let expireDate = $('#expirationDate').val();
        let startDate = $('#startDate').val();
        let siteId = $('#siteSelector').val().toString();
        let familiesSelected = $('#familySelector').val().toString();

        console.log(Object.keys(itemsList).length);
        $.post('");
#nullable restore
#line 272 "C:\Users\sistemas13\Downloads\InaxCore\InaxCore\Views\PromoCodes\CreateCode.cshtml"
           Write(Url.Action("PostPromoCode", "PromoCodes"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', { promoCode, itemsList: JSON.stringify(itemsList), startDate, expireDate, siteId, familiesSelected }).done((data) => {
            if (data.success) {
                toastr.success('Se generó el código promocional');
                setInterval(location.replace('");
#nullable restore
#line 275 "C:\Users\sistemas13\Downloads\InaxCore\InaxCore\Views\PromoCodes\CreateCode.cshtml"
                                         Write(Url.Action("Index", "PromoCodes"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\'), 3000);\r\n            }\r\n        });\r\n    });\r\n\r\n</script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<StoreSite>> Html { get; private set; }
    }
}
#pragma warning restore 1591
