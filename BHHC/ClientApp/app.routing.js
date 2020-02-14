"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var RouterConfig = /** @class */ (function () {
    function RouterConfig($stateProvider, $urlRouterProvider) {
        // Default route
        $urlRouterProvider.otherwise("/candidates");
        // SPA router states
        $stateProvider
            .state("candidates", {
            url: "/candidates",
            views: {
                main: {
                    templateUrl: "candidates/_list.html",
                    controller: "candidatesListController",
                    controllerAs: "ctrl"
                }
            }
        })
            .state("candidateReasons", {
            url: "candidates/:candidateId/reasons",
            views: {
                main: {
                    templateUrl: "reasons/_list.html",
                    controller: "reasonsListController",
                    controllerAs: "ctrl"
                }
            }
        });
    }
    return RouterConfig;
}());
exports.RouterConfig = RouterConfig;
//# sourceMappingURL=app.routing.js.map