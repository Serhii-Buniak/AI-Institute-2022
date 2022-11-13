import { AppState } from "..";

export const getInputSignal = (state: AppState) => {
    return state.inputSignal.elements
}

export const getInputValue = (state: AppState) => {
    return state.inputSignal.inputValue
}
