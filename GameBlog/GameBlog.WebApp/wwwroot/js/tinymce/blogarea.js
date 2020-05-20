tinymce.init({
    selector: 'textarea',
    plugins: 'noneditable powerpaste link autosave autoresize autolink image',
    toolbar: 'undo redo | styleselect  bold italic underline strikethrough blockquote | alignleft aligncenter alignright alignjustify | bullist numlist | link spoiler upload image',
    toolbar_mode: 'floating',
    tinycomments_mode: 'embedded',
    tinycomments_author: 'Author name',
    a11y_advanced_options: true
});