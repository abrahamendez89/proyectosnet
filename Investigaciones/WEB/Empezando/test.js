$(document).on("ready",loadEvents);

function loadEvents(){
   $(".myButton").click(function(evento){

   		if( $("#usuario").val() == 'abraham' && $("#contra").val() == '123' )
   		{
   			var options = {};
   			$(".login").effect("puff",options,500,function(){
   				$(".login").remove();
			});
   		}
   		else
   		{

	      $(".login").addClass( "bounceIn" );
	      setTimeout(function(){
	      			$(".login").removeClass( "bounceIn" );
	      	},500);
  		}
   });
}

function callback() {
      setTimeout(function() {
        $(".login").remove();
      }, 1000 );
    };