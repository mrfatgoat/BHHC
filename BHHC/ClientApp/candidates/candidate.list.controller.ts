import "angular";
import "@uirouter/angularjs";

import { ICandidateService } from "./candidate.service";
import { ICandidateDto } from "./ICandidateDto";

export class CandidateListController implements ng.IController {

    candidates: ICandidateDto[];

    constructor(
        private candidateService: ICandidateService,
        private $state: ng.ui.IStateService) {

        this.candidates = [];
    }

    showCandidateReasons(candidate: ICandidateDto) {
        // candidateReasons({candidateId: c.id, candidate: c})
        this.$state.go("candidateReasons", {
            candidateId: candidate.id,
            candidate: candidate
        });
    }

    $onInit() {
        // Get get the candidates
        this.candidateService.getCandidates()
            .then(c => this.candidates = c);
    }
}