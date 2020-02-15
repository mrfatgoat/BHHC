import { ICandidateDto } from "./ICandidateDto";

export interface ICandidateClient {
    getCandidates(): ng.IHttpPromise<ICandidateDto[]>;
    getCandidate(id: number): ng.IHttpPromise<ICandidateDto>;
}

export function create($http: ng.IHttpService) {
    return new CandidateClient($http);
}

class CandidateClient implements ICandidateClient {

    constructor(private $http: ng.IHttpService) {

    }

    getCandidates(): ng.IHttpPromise<ICandidateDto[]> {
        const route = "api/candidates";
        return this.$http.get<ICandidateDto[]>(route);
    }

    getCandidate(id: number): ng.IHttpPromise<ICandidateDto> {
        const route = `api/candidates/${id}`;
        return this.$http.get<ICandidateDto>(route);
    }
}