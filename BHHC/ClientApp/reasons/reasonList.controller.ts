import "angular";
import { IReasonService } from "./reason.service"
import { IReasonDto } from "./IReasonDto";
import { ICandidateDto } from "../candidates/ICandidateDto";
import { ICandidateService } from "../candidates/candidate.service";

interface IRouterState {
    candidateId: number;     // candidateId from route params
    candidate: ICandidateDto // candidate object, optionally set during state transition (could be null in the case of direct navigation to this controller)
}

export class ReasonListController implements ng.IController {

    candidate: ICandidateDto;
    reasons: IReasonDto[];

    constructor(
        private $stateParams: IRouterState,
        private reasonService: IReasonService,
        private candidateService: ICandidateService) {

        this.reasons = [];
        this.candidate = null;
    }

    $onInit() {
        this.reasonService.getCandidateReasons(this.$stateParams.candidateId)
            .then(r => this.reasons = r);

        if (!this.$stateParams.candidate) {
            // We weren't passed a candidate, so go get them
            this.candidateService.getCandidate(this.$stateParams.candidateId)
                .then(c => this.candidate = c);
        } else {
            this.candidate = this.$stateParams.candidate;
        }
    }
}