import { AppState } from "..";

export const getOutputSignal = (state: AppState) => {
    return state.outputSignal.elements
}

export const getOutputValue = (state: AppState) => {
    return state.outputSignal.inputValue
}
