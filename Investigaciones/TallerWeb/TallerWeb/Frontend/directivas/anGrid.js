(function(){
	var anGrid = angular.module('anGrid',[]);
	 	anGrid.directive('pxGrid', function( ){
        return {
          restrict: 'E',
          scope:{
            url: '@',
            columns:'@'
        },
	    link: function ($scope, element, attr, ctrl){
	    	$scope.grid = element[0];
			$scope.url = attr.url;
            $scope.columns = attr.columns;
            $scope.display = attr.display;
	    },
	    controller:function($scope,$http){
	        angular.element($scope.grid).ready(function () {

	            setTimeout(function(){
	                initGrid();
	            },500);

				
	    	});
	    	var initGrid = function()
	    	{
	    		$scope.columns   = $scope.columns.split(',');
	    		$scope.noColumns = $scope.columns.length;
	    		$scope.display = $scope.display.split(',');

	    		var pxGrid = $scope.grid;
		    	var table  = document.createElement("table");
			    var trHead = document.createElement("tr");
			    table.appendChild(trHead);
			   	for(var i = 0; i < $scope.columns.length; i++)
			   	{
			    	var td = document.createElement("td");
			    	td.innerHTML  = $scope.columns[i];
			    	trHead.appendChild(td);
			   	}
			 	pxGrid.appendChild(table);
		    	$http({
				  method: 'GET',
				  url: $scope.url
				}).then(function successCallback(response) {
					console.log(response.data)
					newRow(table,response.data)

				}, function errorCallback(response) {
					// called asynchronously if an error occurs
					// or server returns response with an error status.
				});
	    	}
	    	var newRow = function(table,data)
	    	{

	    		for(var i = 0; i < data.length; i++)
			   	{
			   		var trBody = document.createElement("tr");
			   		for (var property in data[i])
			   		{	
			   			if(canDisplay(property))
			   			{
							var td = document.createElement("td");
							td.innerHTML   = data[i][property];
							trBody.appendChild(td);
			   			}
			   		}
			   		table.appendChild(trBody);
			   	}
	    	}
	    	var canDisplay = function(prop)
	    	{
	    		for (var i = 0; i < $scope.display.length; i++)
	    		{
	    			if($scope.display[i] == prop)
	    			{
	    				return true;
	    			}
	    		}
	    		return false;
	    	}
	    },
	    controllerAs:'pxGridCtrl'
	}//end return
	});
})();