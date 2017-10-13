/// <reference path="F:\job related\Source\construction\WebPages\fileman/index.html" />
$(document).ready(function () {
    //Check to see if the window is top if not then display button
    $(window).scroll(function () {
        if ($(this).scrollTop() > 180) {
            $('.scrollToTop').fadeIn();
        } else {
            $('.scrollToTop').fadeOut();
        }
    });

    //Click event to scroll to top
    $('.scrollToTop').click(function () {
        $('html, body').animate({ scrollTop: 0 }, 800);
        return false;
    });

    $("#ContentPlaceHolder1_KeyWords").keypress(function (event) {
        if (event.keyCode == 13) {
            event.preventDefault();
        }
    }).tagsinput();
    $("#ContentPlaceHolder1_Tags").keypress(function (event) {
        if (event.keyCode == 13) {
            event.preventDefault();
        }
    }).tagsinput();


    $(document).on('click', '#ContentPlaceHolder1_btnSave', function (e) {



        var messageLength = CKEDITOR.instances['ContentPlaceHolder1_editor1'].getData().replace(/<[^>]*>/gi, '').length;
        if (!messageLength) {
            alert('شما هیچ متنی وارد نکرده اید!');

            e.preventDefault();
            return false;
        }




    });

    $('#ContentPlaceHolder1_FileUpload1').change(function () {
        var filename = $(this).val();
        var lastIndex = filename.lastIndexOf("\\");
        if (lastIndex >= 0) {
            filename = filename.substring(lastIndex + 1);
        }
        $('#filename').html(filename);
    });


    var roxyFileman = '../../fileman/index.html';
    // Replace the <textarea id="editor1"> with a CKEditor
    // instance, using default configuration.
    CKEDITOR.replace('ContentPlaceHolder1_editor1', {
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
