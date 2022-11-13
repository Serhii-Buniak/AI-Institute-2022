import instanse from "."
import SignalEntity from "../interfaces/SignalEntity"

class InputSignalApi {
    private static readonly base = "InputSignal"

    getAll() {
        return instanse.get<SignalEntity[]>(`${InputSignalApi.base}`)
    }

    create(name: string) {
        return instanse.post<SignalEntity>(`${InputSignalApi.base}`, {}, {
            params: {
                name: name
            }
        })
    }

    delete(id: number) {
        return instanse.delete(`${InputSignalApi.base}/${id}`)
    }
}

export default new InputSignalApi()