import { ICandidateDto } from "./ICandidateDto";

export interface ICandidatesClient {
    getCandidates(): ng.IHttpPromise<ICandidateDto[]>;
}

export function Create($http: ng.IHttpService) {
    return new CandidatesClient($http);
}

class CandidatesClient implements ICandidatesClient {

    constructor(private $http: ng.IHttpService) {

    }

    getCandidates(): ng.IHttpPromise<ICandidateDto[]> {
        const route = "api/candidates";
        return this.$http.get<ICandidateDto[]>(route);
    }
}