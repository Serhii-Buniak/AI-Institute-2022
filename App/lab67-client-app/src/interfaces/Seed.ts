import Signal from "./Signal"

interface Seed {
    id: number
    inputSignals: Signal[]
    outputSignals: Signal[]
}

export default Seed