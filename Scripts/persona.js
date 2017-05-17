(function () {
    //vamos a reusar el modulo crado anteriormente
    angular.module("personaapp")
    .controller("PersonaController",function ($scope,$http,PersonaService)
    {
        //inicializando propiedades
        $scope.persona = [];
        //$scope.perorderby = "nombre";
        //$scope.SortReverse = false;

        //cargamos la info de las personas
        PersonaService.getpersonas().then(function (response) {
            $scope.persona = response.data.response;
            $scope.ShowDetails = true;
        },
        function () {
          alert('error ocurrido');
        });

        $scope.Persona = {};

        //funcion de agregar un nuevo registro
        $scope.add_persona = function () {
            $http({
                method: 'POST',
                url: '/Default1/Create',
                data: $scope.Persona
            }).then(function successCallback(response) {
                alert("Product Added Successfully !!!");
            }, function errorCallback(response) {
                alert("Error : " + response.data.ExceptionMessage);
            });
        }
        //funcioon para mostyrar las personas
        /*$scope.load_personas = function () {
            PersonaService.getpersonas().then(function (response) {
                console.log(response.data);
                $scope.persona = response.data;
                $scope.ShowDetails = true;
            },
            function () {
                alert('error ocurrido');
            });
        }*/
    })
    .factory("PersonaService", function ($http) {
        var perfactory = new Object();
        perfactory.getpersonas = function () {
            //llamamos la accion del controlador C#
            return $http.get("Default1/load_personas");
        }
        return perfactory;
    });
})();