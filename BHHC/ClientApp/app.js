"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
require("jquery");
var angular = require("angular");
var app_routing_1 = require("./app.routing");
var candidates_list_controller_1 = require("./candidates/candidates.list.controller");
angular.module("ClientApp", [])
    .config(["$stateProvider", "$urlRouterProvider", function ($stateProvider, $urlRouterProvider) {
        return new app_routing_1.RouterConfig($stateProvider, $urlRouterProvider);
    }])
    .controller("candidatesListController", [function () { return new candidates_list_controller_1.CandidatesListController(); }]);
//# sourceMappingURL=app.js.map