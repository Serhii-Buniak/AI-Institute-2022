import { createSlice, PayloadAction } from "@reduxjs/toolkit"
import SignalEntity from "../../interfaces/SignalEntity"

interface OutputSignalState {
    elements: SignalEntity[]
    inputValue: string
}

const initialState: OutputSignalState = {
    elements: [],
    inputValue: ""
}

const outputSignalSlice = createSlice({
    name: "OutputSignal",
    initialState,
    reducers: {
        init: (state, action: PayloadAction<SignalEntity[]>) => {
            state.elements = action.payload
        },
        add: (state, action: PayloadAction<SignalEntity>) => {
            state.elements.push(action.payload)
        },
        remove: (state, action: PayloadAction<number>) => {
            state.elements = state.elements.filter(i => i.id !== action.payload)
        },
        inputChange: (state, action: PayloadAction<string>) => {
            state.inputValue = action.payload
        },
    }
})


export const outputSignalActions = outputSignalSlice.actions

export default outputSignalSlice.reducer