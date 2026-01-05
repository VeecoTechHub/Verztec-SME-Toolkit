/**
 * @author Prithvi
 */
(function($){
	var methods = {
		init : function( options ) {
			this.each(function(){ 
				def=$.extend({
						width:900,
						height:400,
						Dbox:$(this),
						Dboxheight:$(this).outerHeight(),
						DboxWidth:$(this).outerWidth(),
						overlay:"overlay",
						zoomSpeed:200,
						SlideInSpeed:300,
						SlideInSpeed2:400,
						SlideInSpeed3:400,
						esc:true
					},options);
			  	if(def.Dbox.html()!=null||def.Dbox.html()!=undefined){
			  		Wheight=$(window).height();
			  		Wwidth=$(window).width();
			  		DBtop=Math.round((Wheight-def.Dboxheight)/2);
			  		DBleft=Math.round((Wwidth-def.DboxWidth)/2);
			  		def.Dbox.css({"position":"absolute","left":"left", "z-index":4, "opacity":0,"top":-def.Dboxheight});
					def.Dbox.show();
					scrollT=$(window).scrollTop();
					$('html, body').animate({scrollTop:0}, 'fast', function(){
						$(window).scroll(function(){
							if(def.Dbox.is(":visible")){//alert("visible")
								def.Dbox.css({"top":DBtop+$(this).scrollTop()+"px"});
								overlai.css({"top":$(this).scrollTop()+"px"});
							};
						})	
					});
			  		$("body").append('<div id="'+def.overlay+'"/>');
			  		overlai=$("body").find("div#"+def.overlay);
			  		overlai.css({"width":"50px","height":"50px", "top":"50%","left":"50%"});
			  		overlai.animate({width:"100%", height:"100%",top:"0%", left:"0%"}, def.zoomSpeed, function(){
			  			def.Dbox.css({"left":DBleft+"px"});	
						def.Dbox.animate({top:DBtop+50+"px", opacity:0.8}, def.SlideInSpeed, function(){
							$(this).animate({top:DBtop-20+"px", opacity:1},def.SlideInSpeed2, function(){
								$(this).animate({top:DBtop+"px"},def.SlideInSpeed3);		
							});	
						});		  			
			  		});
			  		//overlay.css({"width":"100%", "height":"50%","top":0,"left":0,"opacity":0.5});
			  		if(def.esc==true){
						$(document).keyup(function(e){
							if(e.keyCode==27){
								if(def.Dbox.is(":visible")&&!def.Dbox.is(":animated")){
								def.Dbox.animate({top:DBtop+50+"px"}, def.SlideInSpeed2, function(){
									def.Dbox.animate({top:-DBtop+"px", opacity:0},def.SlideInSpeed2, function(){
										$(this).hide();
										overlai.animate({width:"1px", height:"1px",top:"50%", left:"50%"}, def.zoomSpeed, function(){
											$(this).remove();
											$('html, body').animate({scrollTop:scrollT}, 'fast');
										});
									});	
								});
								};			
							};	
						});	
					};//if esc key press ends
					$(window).resize(function(){
						var RwinHeight=$(window).height();
						var RwinWidth=$(window).width();
						var RDBtop=Math.round((RwinHeight-def.Dboxheight)/2);
						var RDBleft=Math.round((RwinWidth-def.DboxWidth)/2);
						def.Dbox.css({"left":RDBleft+"px", "top":RDBtop+"px"});	
						overlai.css({"top":$(window).scrollTop()+"px"});
					});
			  	}else {
			  		alert("Unable to find Dialog content");
			  	};
			  	return def;
		  	});//return		  	
		},
		close:function(){
			if(overlai.is(":visible")){
			//	this.each(function(){
					def.Dbox.animate({top:DBtop+50+"px"}, def.SlideInSpeed, function(){
						$(this).animate({top:-DBtop+"px", opacity:0},def.SlideInSpeed2, function(){
							$(this).hide();
							overlai.animate({width:"1px", height:"1px",top:"50%", left:"50%"}, def.zoomSpeed, function(){
								$(this).remove();
								$('html, body').animate({scrollTop:scrollT}, 'fast');
								//alert(scrollT);
							});
						});	
					});		
				//});
			};
		}
	  };

	  $.fn.dialog = function( method ) {		
		// Method calling logic
		if ( methods[method] ) {
		  return methods[ method ].apply( this, Array.prototype.slice.call( arguments, 1 ));
		} else if ( typeof method === 'object' || ! method ) {
		  return methods.init.apply( this, arguments );
		} else {
		  $.error( 'Method ' +  method + ' does not exist on jQuery.tooltip' );
		}    
  
  }
})(jQuery);


