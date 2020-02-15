import "jquery";
import * as angular from "angular";
import "@uirouter/angularjs";


import "./app.templates";

import { RouterConfig } from "./app.routing";
import { CandidateListController } from "./candidates/candidate.list.controller"
import * as CandidateService from "./candidates/candidate.service";
import * as CandidateClient from "./candidates/candidate.client";

angular.module("ClientApp", ["app.templates", "ui.router"])

    .config(["$stateProvider", "$urlRouterProvider", ($stateProvider, $urlRouterProvider) =>
        new RouterConfig($stateProvider, $urlRouterProvider)])

    // Candidate services
    .controller("candidatesListController", [
        "candidatesService",
        (candidatesService) => new CandidateListController(candidatesService)])

    .service("candidatesService", ["candidatesClient", (candidatesClient) => CandidateService.Create(candidatesClient)])
    .service("candidatesClient", ["$http", ($http) => CandidateClient.Create($http)]);