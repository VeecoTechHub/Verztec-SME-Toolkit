    
    tinyMCE.init({ 
    mode : "textareas", 
    theme : "advanced",
    file_browser_callback : "myFileBrowser",//(for image uploader icon in inser/edit image)
    //convert_urls : false,
    force_br_newlines : true,
    plugins : 'safari,pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template',
    
    // Theme options
    theme_advanced_buttons1 : "save,newdocument,|,bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,styleselect,formatselect,fontselect,fontsizeselect",
    theme_advanced_buttons2 : "cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,image,cleanup,help,code,|,insertdate,inserttime,preview,|,forecolor,backcolor",
    theme_advanced_buttons3 : "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen",
    theme_advanced_buttons4 : "insertlayer,moveforward,movebackward,absolute,|,styleprops,|,cite,abbr,acronym,del,ins,attribs,|,visualchars,nonbreaking,template,pagebreak,myFileButton,mybutton",
    
    theme_advanced_toolbar_location : "top", 
    theme_advanced_toolbar_align : "left", 
    theme_advanced_statusbar_location : "bottom", 
    theme_advanced_resizing : false,
    
    // Example content CSS (should be your site CSS)
	content_css :  "../tiny_mce/css/content.css",   

	// Drop lists for link/image/media/template dialogs
	template_external_list_url : "tiny_mce/lists/template_list.js",
	external_link_list_url : "tiny_mce/lists/link_list.js",
	external_image_list_url : "tiny_mce/lists/image_list.js",
	media_external_list_url : "tiny_mce/lists/media_list.js",
    
    
    setup : function(ed) {
        // Add a custom button
        ed.addButton('mybutton', {
            title : 'Insert Image',
            image : 'image/insertimage.gif',
            onclick : function() {
				// Add you own code to execute something on click
				ed.focus();
				 //var cmsURL = "http://localhost/editorsample/tiny_mce/gallery/ImageManager.aspx";
				 var cmsURL = "../tiny_mce/gallery/ImageManager.aspx";
				 //var cmsURL = "tiny_mce/gallery/ImageGallery.aspx?Id=elm1";     
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
            image : 'image/FileManager.bmp',
            onclick : function() {
				// Add you own code to execute something on click
				ed.focus();
				 //var cmsURL = "http://localhost/editorsample/tiny_mce/gallery/FileManager.aspx";
				 var cmsURL = "../tiny_mce/gallery/FileManager.aspx";
				 //var cmsURL = "tiny_mce/gallery/ImageGallery.aspx?Id=elm1";     
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

        /* If you work with sessions in PHP and your client doesn't accept cookies you might need to carry
           the session name and session ID in the request string (can look like this: "?PHPSESSID=88p0n70s9dsknra96qhuk6etm5").
           These lines of code extract the necessary parameters and add them back to the filebrowser URL again. */

//        var cmsURL = window.location.toString();    // script URL - use an absolute path!
//        if (cmsURL.indexOf("?") < 0) {
//            //add the type as the only query parameter
//            cmsURL = cmsURL + "?type=" + type;
//        }
//        else {
//            //add the type as an additional query parameter
//            // (PHP session ID is now included if there is one at all)
//            cmsURL = cmsURL + "&type=" + type;
//        }
        if(type == 'image')
        {
            //var cmsURL = "http://localhost/editorsample/tiny_mce/gallery/ImageManager.aspx";
            var cmsURL = "../tiny_mce/gallery/ImageManager.aspx";
        }
        else
        {
           //var cmsURL = "http://localhost/editorsample/tiny_mce/gallery/FileManager.aspx";
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
            input : field_name
        });
        return false;
   }
    