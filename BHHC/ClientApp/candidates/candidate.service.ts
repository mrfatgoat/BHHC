import { ICandidateDto } from "./ICandidateDto";
import { ICandidateClient } from "./candidate.client";

export interface ICandidateService {
    getCandidates(): ng.IPromise<ICandidateDto[]>;
    getCandidate(id: number): ng.IPromise<ICandidateDto>;
}

export function create(candidateClient: ICandidateClient): ICandidateService {
    return new CandidateService(candidateClient);
}

class CandidateService implements ICandidateService {

    constructor(private candidateClient: ICandidateClient) { }

    getCandidates(): ng.IPromise<ICandidateDto[]> {
        return this.candidateClient.getCandidates()
            .then(response => response.data);
    }

    getCandidate(id: number): ng.IPromise<ICandidateDto> {
        return this.candidateClient.getCandidate(id)
            .then(response => response.data);
    }
}