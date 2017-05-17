(function () {
    //creando el modlo usado para crear la app
    var personaapp = angular.module("personaapp", []);

    //definimos el mapeo de las rutas.
    var angularRoutingApp = angular.module('angularRoutingApp', ['ngRoute']);

    // Configuración de las rutas
    angularRoutingApp.config(function ($routeProvider) {

        $routeProvider
            .when('/', {
                templateUrl: 'Default1/Index',
                controller: 'mensajecontroller'
            })
            .when('/Nuevo', {
                templateUrl: 'Default1/Create.cshtml',
                controller: 'PersonaController'
            })
            .otherwise({
                redirectTo: '/'
            });
    });


    //creating controller
    personaapp.controller('mensajecontroller', function ($scope) {
        //agregando nuevo mensaje 
        $scope.Message = "Prueba de mvc con angular";
        console.log($scope);
    });

})();