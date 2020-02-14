import "jquery";
import * as angular from "angular";

import { RouterConfig } from "./app.routing";
import { CandidatesListController } from "./candidates/candidates.list.controller"

angular.module("ClientApp", [])

    .config(["$stateProvider", "$urlRouterProvider", ($stateProvider, $urlRouterProvider) =>
        new RouterConfig($stateProvider, $urlRouterProvider)])

    .controller("candidatesListController", [() => new CandidatesListController()]);