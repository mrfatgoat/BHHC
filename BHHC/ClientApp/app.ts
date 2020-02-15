import "jquery";
import * as angular from "angular";
import "@uirouter/angularjs";

import "./app.templates";

import { RouterConfig } from "./app.routing";
import { CandidateListController } from "./candidates/candidate.list.controller"
import * as CandidateService from "./candidates/candidate.service";
import * as CandidateClient from "./candidates/candidate.client";
import { ReasonListController } from "./reasons/reason.list";
import * as ReasonService from "./reasons/reason.service";
import * as ReasonClient from "./reasons/reason.client";

angular.module("ClientApp", ["app.templates", "ui.router"])

    .config(["$stateProvider", "$urlRouterProvider", ($stateProvider, $urlRouterProvider) =>
        new RouterConfig($stateProvider, $urlRouterProvider)])

    // Candidate services
    .controller("candidateListController", [
        "candidateService",
        (candidateService) => new CandidateListController(candidateService)])

    .service("candidateService", ["candidateClient", (candidatesClient) => CandidateService.create(candidatesClient)])
    .service("candidateClient", ["$http", ($http) => CandidateClient.create($http)])


    // Reason services
    .controller("reasonListController", [
        "$stateParams",
        "reasonService",
        "candidateService",
        ($stateParams, reasonService, candidateService) => new ReasonListController($stateParams, reasonService, candidateService)])

    .service("reasonService", ["reasonClient", (reasonClient) => ReasonService.create(reasonClient)])
    .service("reasonClient", ["$http", ($http) => ReasonClient.create($http)]);