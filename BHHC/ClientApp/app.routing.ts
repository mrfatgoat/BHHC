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
}