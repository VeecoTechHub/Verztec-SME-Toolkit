    
    tinyMCE.init({ 
    //mode : "textareas", 
    mode : "exact", 
    elements : txt,
    theme : "advanced",
    file_browser_callback : "myFileBrowser",//(for image uploader icon in inser/edit image)
    //convert_urls : false,
    force_p_newlines : false,
    force_br_newlines : true,
    plugins : 'safari,pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template',

    // Theme options
    theme_advanced_buttons1: "bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,styleselect,formatselect,fontselect,fontsizeselect,image,code,myFileButton,mybutton,link,unlink,anchor",
    theme_advanced_buttons2: "",
    //    theme_advanced_buttons2 : "cut,copy,paste,pastetext,pasteword,selectall,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,|,insertdate,inserttime,preview,|,forecolor,backcolor",
    //    theme_advanced_buttons3 : "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,media,advhr,|,print,|,ltr,rtl,|,fullscreen",
    
    
    theme_advanced_source_editor_width : "200px", 
    
    theme_advanced_toolbar_location : "top", 
    theme_advanced_toolbar_align : "left", 
    theme_advanced_statusbar_location : "bottom", 
    theme_advanced_resizing : false,
    
    // Example content CSS (should be your site CSS)
	content_css :"../../SGCares_Css/StyleSheet.css",    // "css/content.css",
	

	// Drop lists for link/image/media/template dialogs
	template_external_list_url : "tiny_mce/lists/template_list.js",
	external_link_list_url : "tiny_mce/lists/link_list.js",
	external_image_list_url : "tiny_mce/lists/image_list.js",
	media_external_list_url : "tiny_mce/lists/media_list.js",
    
    paste_auto_cleanup_on_paste : true,
 paste_convert_headers_to_strong : false,
    paste_strip_class_attributes : "all",
    paste_insert_word_content_callback : "convertWord",
    paste_remove_styles: false,
    paste_remove_styles_if_webkit: false,
    paste_retain_style_properties: true,
    paste_strip_class_attributes: "none",
    paste_remove_spans: false,
    paste_convert_middot_lists:true,
    
    setup : function(ed) {
        // Add a custom button
        ed.addButton('mybutton', {
            title : 'Insert Image',
            image : '../tiny_mce/gallery/images/insertimage.gif',
            onclick : function() {
				// Add you own code to execute something on click
				ed.focus();
				 var cmsURL = "../tiny_mce/gallery/ImageManager.aspx";
				 //var cmsURL = "http://202.172.218.205/TinyMCEEditor/tiny_mce/gallery/ImageManager.aspx";
				 tinyMCE.activeEditor.windowManager.open({
				 file: cmsURL,
                    title: 'ImageManager',
                    width: 800,  // Your dimensions may differ - toy around with them!
                    height: 500,
                    resizable: "no",
                    inline: 1,  // This parameter only has an effect if you use the inlinepopups plugin!
                    close_previous: "no"
                }, {
                window : window,
                input : ed
                });
                return false;
            }
        });
        
        ed.addButton('myFileButton', {
            title : 'Insert File',
            image : '../tiny_mce/gallery/images/FileManager.bmp',
            onclick : function() {
				// Add you own code to execute something on click
				ed.focus();
				 var cmsURL = "../tiny_mce/gallery/FileManager.aspx";
				 //var cmsURL = "http://202.172.218.205/TinyMCEEditor/tiny_mce/gallery/FileManager.aspx";
				 tinyMCE.activeEditor.windowManager.open({
				 file: cmsURL,
                    title: 'FileManager',
                    width: 800,  // Your dimensions may differ - toy around with them!
                    height: 500,
                    resizable: "no",
                    inline: 1,  // This parameter only has an effect if you use the inlinepopups plugin!
                    close_previous: "no"
                }, {
                window : window,
                input : ed
                });
                return false;
            }
        });
    }
});

    function myFileBrowser (field_name, url, type, win) 
    {
        //alert("Field_Name: " + field_name + "\nURL: " + url + "\nType: " + type + "\nWin: " + win); // debug/testing

        if(type == 'image')
        {
            var cmsURL = "../tiny_mce/gallery/ImageManager.aspx";
            //var cmsURL = "http://202.172.218.205/TinyMCEEditor/tiny_mce/gallery/ImageManager.aspx";
        }
        else
        {
           var cmsURL = "../tiny_mce/gallery/FileManager.aspx";
          
        }
        
        tinyMCE.activeEditor.windowManager.open({
            file : cmsURL,
            title : 'My File Browser',
            width : 800,  // Your dimensions may differ - toy around with them!
            height : 500,
            resizable : "yes",
            inline : "yes",  // This parameter only has an effect if you use the inlinepopups plugin!
            close_previous : "no"
        }, {
            window : win,
            input : field_name,
            type : type
        });
        return false;
   }
   
   function convertWord(type, content) {
	switch (type) {
		// Gets executed before the built in logic performes it's cleanups
		case "before":
			//content = content.toLowerCase(); // Some dummy logic
			//alert(content);
			break;

		// Gets executed after the built in logic performes it's cleanups
		case "after":
			//content = content.toLowerCase(); // Some dummy logic
			//alert(content);
			break;
	}

	return content;
}
