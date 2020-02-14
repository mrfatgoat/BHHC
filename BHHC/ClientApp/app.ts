import "jquery";
import * as angular from "angular";
import "@uirouter/angularjs";


import "./app.templates";

import { RouterConfig } from "./app.routing";
import { CandidatesListController } from "./candidates/candidates.list.controller"

angular.module("ClientApp", ["app.templates", "ui.router"])

    .config(["$stateProvider", "$urlRouterProvider", ($stateProvider, $urlRouterProvider) =>
        new RouterConfig($stateProvider, $urlRouterProvider)])

    .controller("candidatesListController", [() => new CandidatesListController()]);