import { AppState } from "..";

export const getNeuronInputs = (state: AppState) => {
    return state.neuron.inputs
}

export const getNeuronOutputs = (state: AppState) => {
    return state.neuron.outputs
}
