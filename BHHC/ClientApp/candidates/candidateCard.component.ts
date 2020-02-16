import { ICandidateDto } from "./ICandidateDto";

export function getComponentDefinition(): ng.IComponentOptions {
    var ddo: ng.IComponentOptions = {
        templateUrl: "candidates/_candidateCard.html",
        bindings: {
            candidate: "=",
            onViewMore: "&"
        },
        controllerAs: "ctrl",
        controller: [() => new CandidateCardComponent()]
    }

    return ddo;
}

interface IViewMoreFunc {
    (candidate: ICandidateDto): never;
}

class CandidateCardComponent implements ng.IComponentController {

    candidate: ICandidateDto;
    onViewMore: IViewMoreFunc

    constructor() { }

    viewMore() {
        this.onViewMore(this.candidate);
    }
}