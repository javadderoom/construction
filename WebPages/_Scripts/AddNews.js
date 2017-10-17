
$(document).ready(function () {
    //Check to see if the window is top if not then display button


    $("#Content_KeyWords").keypress(function (event) {
        if (event.keyCode == 13) {
            event.preventDefault();
        }
    }).tagsinput();
    $("#Content_Tags").keypress(function (event) {
        if (event.keyCode == 13) {
            event.preventDefault();
        }
    }).tagsinput();

    ///////////////////////////////////////////////////
    $(document).on('click', '#Content_btnSave', function (e) {



        var messageLength = CKEDITOR.instances['Content_editor1'].getData().replace(/<[^>]*>/gi, '').length;
        if (!messageLength) {
            alert('شما هیچ متنی وارد نکرده اید!');

            e.preventDefault();
            return false;
        }




    });
    //////////////////////////////////////////////////////////////////////////////////////
    $('#Content_FileUpload1').change(function () {
        var filename = $(this).val();
        var lastIndex = filename.lastIndexOf("\\");
        if (lastIndex >= 0) {
            filename = filename.substring(lastIndex + 1);
        }
        $('#filename').html(filename);
    });
    /////////////////////////////////////////////////////////////////////
    var roxyFileman = '../../fileman/index.html';
    // Replace the <textarea id="editor1"> with a CKEditor
    // instance, using default configuration.
    CKEDITOR.replace('Content_editor1', {
        toolbar: [
        { name: 'document', items: ['Save', 'NewPage', 'Preview', 'Print', '-', 'Templates'] },
        { name: 'clipboard', items: ['Cut', 'Copy', 'Paste', 'PasteText', '-', 'Undo', 'Redo'] },
        { name: 'editing', items: ['Find', 'Replace', '-', 'SelectAll', '-'] },
         '/',
        { name: 'basicstyles', items: ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript', '-', 'CopyFormatting', 'RemoveFormat'] },
        { name: 'paragraph', items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', '-', 'BidiLtr', 'BidiRtl'] },
        { name: 'links', items: ['Link', 'Unlink', 'Anchor'] },
        { name: 'insert', items: ['Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak'] },
        '/',
        { name: 'styles', items: ['Styles', 'Format', 'Font', 'FontSize'] },
        { name: 'colors', items: ['TextColor', 'BGColor'] },
        { name: 'tools', items: ['Maximize'] }
        ],
        language: 'fa',
        contentsLangDirection: 'rtl',
        toolbarDirection: 'rtl',
        filebrowserBrowseUrl: roxyFileman,
        filebrowserImageBrowseUrl: roxyFileman + '?type=image',
        removeDialogTabs: 'link:upload;image:upload', resize_maxHeight: '830'
    });




});
