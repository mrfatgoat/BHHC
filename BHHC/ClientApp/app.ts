import "jquery";
import * as angular from "angular";
import "@uirouter/angularjs";


import "./app.templates";

import { RouterConfig } from "./app.routing";
import { CandidatesListController } from "./candidates/candidates.list.controller"
import * as CandidateService from "./candidates/candidates.service";
import * as CandidateClient from "./candidates/candidates.client";

angular.module("ClientApp", ["app.templates", "ui.router"])

    .config(["$stateProvider", "$urlRouterProvider", ($stateProvider, $urlRouterProvider) =>
        new RouterConfig($stateProvider, $urlRouterProvider)])

    // Candidate services
    .controller("candidatesListController", [
        "candidatesService",
        (candidatesService) => new CandidatesListController(candidatesService)])

    .service("candidatesService", ["candidatesClient", (candidatesClient) => CandidateService.Create(candidatesClient)])
    .service("candidatesClient", ["$http", ($http) => CandidateClient.Create($http)]);