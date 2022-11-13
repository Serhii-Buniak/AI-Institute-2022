import { AppState } from "..";

export const getSeeds = (state: AppState) => {
    return state.seed.elements
}