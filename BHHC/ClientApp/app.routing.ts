export class RouterConfig {

    constructor(
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider) {

        // Default route
        $urlRouterProvider.otherwise("/candidates");

        // SPA router states
        $stateProvider
            .state("candidates", {
                url: "/candidates",
                views: {
                    main: {
                        templateUrl: "candidates/_candidateList.html",
                        controller: "candidateListController",
                        controllerAs: "ctrl"
                    }
                }
            })
            .state("candidateReasons", {
                url: "/candidates/:candidateId/reasons",
                params: {
                    candidate: {
                        value: null
                    }
                },
                views: {
                    main: {
                        templateUrl: "reasons/_reasonList.html",
                        controller: "reasonListController",
                        controllerAs: "ctrl"
                    }
                }
            });
    }
}