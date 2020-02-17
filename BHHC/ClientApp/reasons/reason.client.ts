import { IReasonDto } from "./IReasonDto";

export interface IReasonClient {
    getCandidateReasons(candidateId: number): ng.IHttpPromise<IReasonDto[]>;
}

export function create($http: ng.IHttpService): IReasonClient {
    return new ReasonClient($http);
}

class ReasonClient implements IReasonClient {
    
    constructor(private $http: ng.IHttpService) { }

    getCandidateReasons(candidateId: number): ng.IHttpPromise<IReasonDto[]> {
        const route = `api/candidates/${candidateId}/reasons`;
        return this.$http.get<IReasonDto[]>(route);
    }
}