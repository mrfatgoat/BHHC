import { ICandidateDto } from "./CandidateDto";
import { ICandidatesClient } from "./candidates.client";

export interface ICandidateService {
    getCandidates(): ng.IPromise<ICandidateDto[]>;
}

export function Create(candidatesClient: ICandidatesClient): ICandidateService {
    return new CandidateService(candidatesClient);
}

class CandidateService implements ICandidateService {

    constructor(private candidatesClient: ICandidatesClient) {

    }

    getCandidates(): ng.IPromise<ICandidateDto[]> {
        return this.candidatesClient.getCandidates()
            .then(response => response.data);
    }
}