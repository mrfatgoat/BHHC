import { IReasonDto } from "./IReasonDto";
import { IReasonClient } from "./reason.client";

export interface IReasonService {
    getCandidateReasons(candidateId: number): ng.IPromise<IReasonDto[]>;
}

export function create(reasonClient: IReasonClient): IReasonService {
    return new ReasonService(reasonClient);
}

class ReasonService implements IReasonService {
    
    constructor(private reasonClient: IReasonClient) { }

    getCandidateReasons(candidateId: number): ng.IPromise<IReasonDto[]> {
        return this.reasonClient.getCandidateReasons(candidateId)
            .then(response => response.data);
    }
}