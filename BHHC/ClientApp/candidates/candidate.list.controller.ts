import "angular";
import { ICandidateService } from "./candidate.service";
import { ICandidateDto } from "./ICandidateDto";

export class CandidateListController implements ng.IController {

    candidates: ICandidateDto[];

    constructor(private candidateService: ICandidateService) {
        this.candidates = [];
    }

    $onInit() {
        // Get get the candidates
        this.candidateService.getCandidates()
            .then(c => this.candidates = c);
    }
}