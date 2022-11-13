import { createSlice, PayloadAction } from "@reduxjs/toolkit"
import Seed from "../../interfaces/Seed"

interface SeedState {
    elements: Seed[]
}

const initialState: SeedState = {
    elements: []
}

const seedSlice = createSlice({
    name: "Seed",
    initialState,
    reducers: {
        init: (state, action: PayloadAction<Seed[]>) => {
            state.elements = action.payload
        },
        add: (state, action: PayloadAction<Seed>) => {
            state.elements.push(action.payload)
        },
        remove: (state, action: PayloadAction<number>) => {
            state.elements = state.elements.filter(i => i.id !== action.payload)
        },
        removeAll: (state) => {
            state.elements = []
        },
    }
})


export const seedActions = seedSlice.actions

export default seedSlice.reducer