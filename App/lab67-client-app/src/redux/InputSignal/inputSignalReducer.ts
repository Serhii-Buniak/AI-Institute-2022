import { createSlice, PayloadAction } from "@reduxjs/toolkit"
import SignalEntity from "../../interfaces/SignalEntity"

interface InputSignalState {
    elements: SignalEntity[]
    inputValue: string
}

const initialState: InputSignalState = {
    elements: [],
    inputValue: ""
}

const inputSignalSlice = createSlice({
    name: "InputSignal",
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


export const inputSignalActions = inputSignalSlice.actions

export default inputSignalSlice.reducer