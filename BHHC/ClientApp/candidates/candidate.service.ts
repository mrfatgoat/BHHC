import { ICandidateDto } from "./ICandidateDto";
import { ICandidateClient } from "./candidate.client";

export interface ICandidateService {
    getCandidates(): ng.IPromise<ICandidateDto[]>;
}

export function Create(candidatesClient: ICandidateClient): ICandidateService {
    return new CandidateService(candidatesClient);
}

class CandidateService implements ICandidateService {

    constructor(private candidatesClient: ICandidateClient) {

    }

    getCandidates(): ng.IPromise<ICandidateDto[]> {
        return this.candidatesClient.getCandidates()
            .then(response => response.data);
    }
}