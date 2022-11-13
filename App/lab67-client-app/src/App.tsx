import './App.css'
import InputSection from './components/InputSection'
import OutputSection from './components/OutputSection'
import TableTeaching from './components/TableTeaching'
import Teacher from './components/Teacher'

const App = () => {
  return (
    <div className="App">
      <InputSection />
      <OutputSection />
      <TableTeaching />
      <Teacher />
    </div>
  )
}

export default App
