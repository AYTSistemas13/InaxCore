#pragma checksum "C:\Users\sistemas13\Downloads\InaxCore\InaxCore\Views\CreditRequests\CreditRequest.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "614de492cc50c400c3e6a925eaa2b2f7f596469f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CreditRequests_CreditRequest), @"mvc.1.0.view", @"/Views/CreditRequests/CreditRequest.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"614de492cc50c400c3e6a925eaa2b2f7f596469f", @"/Views/CreditRequests/CreditRequest.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de2440f23d8fea7a6de71ba0896f6fbc3bb152e4", @"/Views/_ViewImports.cshtml")]
    public class Views_CreditRequests_CreditRequest : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CreditRequestModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("dropzone"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("max-height: 400px !important; overflow-y: scroll;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\sistemas13\Downloads\InaxCore\InaxCore\Views\CreditRequests\CreditRequest.cshtml"
  
    ViewData["Title"] = "Datos Solicitud";
    Dictionary<string, string[]> extensionFileIcon = new Dictionary<string, string[]>() {
        {"png", new string[] {"fa-file-image", "btn-outline-secondary" } },
        {"jpg", new string[] {"fa-file-image", "btn-outline-secondary" } },
        {"jpeg", new string[] {"fa-file-image", "btn-outline-secondary" } },
        {"gif", new string[] {"fa-file-image", "btn-outline-secondary" } },
        {"pdf", new string[] {"fa-file-pdf", "btn-outline-danger" } },
        {"doc", new string[] {"fa-file-word", "btn-outline-primary" } },
        {"docx", new string[] {"fa-file-word", "btn-outline-primary" } },
        {"odt", new string[] {"fa-file-word", "btn-outline-primary" } }
    };

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container-fluid mx-0 my-5 pt-5\">\r\n    <div class=\"row\">\r\n        <div class=\"col-12\">\r\n            <h1>");
#nullable restore
#line 19 "C:\Users\sistemas13\Downloads\InaxCore\InaxCore\Views\CreditRequests\CreditRequest.cshtml"
           Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </h1>
        </div>
    </div>

    <div class=""row"">
        <div class="" col-8"">
            <div class=""card"">
                <div class=""card-header"">
                    <div class=""row"">
                        Archivos
                        <div class=""col-11 d-flex justify-content-end"">
                            <button class=""btn btn-primary"" style=""font-size: 16px !important;"" id=""uploadFiles""><i class=""fa fa-file-upload""></i> Subir Archivos</button>
                        </div>
                    </div>
                </div>
                <div class=""card-body"" style=""min-height: 200px"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "614de492cc50c400c3e6a925eaa2b2f7f596469f6650", async() => {
                WriteLiteral("\r\n                        <input type=\"hidden\" name=\"Ov\" id=\"Ov\"");
                BeginWriteAttribute("value", " value=\"", 1813, "\"", 1830, 1);
#nullable restore
#line 36 "C:\Users\sistemas13\Downloads\InaxCore\InaxCore\Views\CreditRequests\CreditRequest.cshtml"
WriteAttributeValue("", 1821, Model.Ov, 1821, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                        <input type=\"hidden\" name=\"RequestId\" id=\"RequestId\"");
                BeginWriteAttribute("value", " value=\"", 1912, "\"", 1929, 1);
#nullable restore
#line 37 "C:\Users\sistemas13\Downloads\InaxCore\InaxCore\Views\CreditRequests\CreditRequest.cshtml"
WriteAttributeValue("", 1920, Model.Id, 1920, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                        <input type=\"hidden\" name=\"AttachmentType\" value=\"1\" />\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 35 "C:\Users\sistemas13\Downloads\InaxCore\InaxCore\Views\CreditRequests\CreditRequest.cshtml"
AddHtmlAttributeValue("", 1584, Url.Action("UploadFiles", "CreditRequests"), 1584, 44, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>
            </div>
        </div>
        <div class="" col-4"">
            <div class=""row"">
                <div class=""col-12"">
                    <div class=""card"">
                        <div class=""card-header"">
                            <i class=""fa fa-comment-alt""></i> Comentarios
                        </div>
                        <div class=""card-body p-0"">
                            <div class=""pr-4 pr-4"" id=""messageBox"" style=""height: 300px; overflow-y: scroll;"">
");
#nullable restore
#line 52 "C:\Users\sistemas13\Downloads\InaxCore\InaxCore\Views\CreditRequests\CreditRequest.cshtml"
                                 foreach (CreditReqAttachmentModel requestAttachment in ViewData["requestAttachments"] as List<CreditReqAttachmentModel>)
                                {
                                    if (requestAttachment.AttachmentType == 1) continue;
                                    if (requestAttachment.MessageFrom == 2)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        <div class=""row justify-content-start"">
                                            <div class=""col-10 m-0 p-0 pl-3"">
                                                <div class=""row justify-content-start ml-1"">
                                                    <div class=""alert alert-secondary mb-1 mt-1 py-2"" role=""alert"" style=""max-width: 100%"">
                                                        ");
#nullable restore
#line 61 "C:\Users\sistemas13\Downloads\InaxCore\InaxCore\Views\CreditRequests\CreditRequest.cshtml"
                                                   Write(requestAttachment.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </div>\r\n                                                </div>\r\n                                            </div>\r\n                                        </div>\r\n");
#nullable restore
#line 66 "C:\Users\sistemas13\Downloads\InaxCore\InaxCore\Views\CreditRequests\CreditRequest.cshtml"

                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        <div class=""row justify-content-end"">
                                            <div class=""col-10 m-0 p-0"">
                                                <div class=""row justify-content-end mr-1"">
                                                    <div class=""alert alert-success mb-1 mt-1 py-2"" role=""alert"" style=""max-width: 100%"">
                                                        ");
#nullable restore
#line 74 "C:\Users\sistemas13\Downloads\InaxCore\InaxCore\Views\CreditRequests\CreditRequest.cshtml"
                                                   Write(requestAttachment.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </div>\r\n                                                </div>\r\n                                            </div>\r\n                                        </div>\r\n");
#nullable restore
#line 79 "C:\Users\sistemas13\Downloads\InaxCore\InaxCore\Views\CreditRequests\CreditRequest.cshtml"
                                    }

                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </div>
                            <div class=""row my-1 pl-4"" style=""width: 100%;"">
                                <div class=""col-11"" style=""padding: 0;""><input type=""text"" class=""form-control"" placeholder=""Escribe Algo.."" id=""messageInput"" /></div>
                                <div class=""col-1"" style=""padding: 0;""><button class=""btn btn-outline-primary"" id=""sendMessage""><i class=""fa fa-paper-plane""></i></button></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""row pt-2"">
                <div class=""col-12"">
                    <div class=""card"">
                        <div class=""card-header"">
                            Documentos
                        </div>
                        <div class=""card-body"" style=""max-height: 200px; overflow-y: scroll;"">
                            <div class=""row"">
");
#nullable restore
#line 99 "C:\Users\sistemas13\Downloads\InaxCore\InaxCore\Views\CreditRequests\CreditRequest.cshtml"
                                 foreach (CreditReqAttachmentModel requestAttachment in ViewData["requestAttachments"] as List<CreditReqAttachmentModel>)
                                {
                                    string fileExtension = requestAttachment.FileUrl.Split("/").Last().Split(".").Last();
                                    string fileColor = extensionFileIcon.ContainsKey(fileExtension) ? extensionFileIcon[fileExtension][1] : "btn-outline-secondary";
                                    string fileIcon = extensionFileIcon.ContainsKey(fileExtension) ? extensionFileIcon[fileExtension][0] : "fa-file";
                                    if (requestAttachment.AttachmentType == 2) continue;

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <div class=\"col-3 text-center pt-2\"><a");
            BeginWriteAttribute("class", " class=\"", 6315, "\"", 6337, 2);
            WriteAttributeValue("", 6323, "btn", 6323, 3, true);
#nullable restore
#line 105 "C:\Users\sistemas13\Downloads\InaxCore\InaxCore\Views\CreditRequests\CreditRequest.cshtml"
WriteAttributeValue(" ", 6326, fileColor, 6327, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 6338, "\"", 6376, 2);
            WriteAttributeValue("", 6345, "../..", 6345, 5, true);
#nullable restore
#line 105 "C:\Users\sistemas13\Downloads\InaxCore\InaxCore\Views\CreditRequests\CreditRequest.cshtml"
WriteAttributeValue("", 6350, requestAttachment.FileUrl, 6350, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\" style=\"font-size:30px !important\"><i");
            BeginWriteAttribute("class", " class=\"", 6430, "\"", 6450, 2);
            WriteAttributeValue("", 6438, "fa", 6438, 2, true);
#nullable restore
#line 105 "C:\Users\sistemas13\Downloads\InaxCore\InaxCore\Views\CreditRequests\CreditRequest.cshtml"
WriteAttributeValue(" ", 6440, fileIcon, 6441, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i></a></div>\r\n");
#nullable restore
#line 106 "C:\Users\sistemas13\Downloads\InaxCore\InaxCore\Views\CreditRequests\CreditRequest.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

    <script>
        Dropzone.autoDiscover = false;
        var myDropzone = new Dropzone('.dropzone', {
            dictDefaultMessage: '<h4>Arrastre archivos o de click aqui para subirlos</h4>',
            dictRemoveFile: 'Eliminar Archivo',
            parallelUploads: 20,
            addRemoveLinks: true,
            duplicateCheck: true,
            autoProcessQueue: false,
            uploadMultiple: true
        });

        $('#messageBox').animate({ scrollTop: document.body.scrollHeight }, ""slow"");

        $('#uploadFiles').click(function () {
            myDropzone.processQueue();
        });

        myDropzone.on(""queuecomplete"", function (file) {
            toastr.success('Carga Completada');
            setTimeout(() => {
                location.reload();
            }, 2000);
        });


        $('#sendMessage').click(function () {
            let postInfo = {
                Ov : $('#Ov').val(),
                RequestId : $('#RequestId').val(),
       ");
                WriteLiteral("         Message : $(\'#messageInput\').val(),\r\n                AttachmentType : 2,\r\n                MessageFrom : 1\r\n            }\r\n\r\n            $.post(\'");
#nullable restore
#line 155 "C:\Users\sistemas13\Downloads\InaxCore\InaxCore\Views\CreditRequests\CreditRequest.cshtml"
               Write(Url.Action("PostMessage", "CreditRequests"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\', postInfo, function (data) {\r\n                location.reload();\r\n            });\r\n        });\r\n\r\n    </script>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CreditRequestModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
